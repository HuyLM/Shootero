using UnityEngine;

public class FrontBullet : BulletBase {
    private float speed;
    private float accelerationSpeed = 0f;
    [SerializeField] protected Rigidbody2D myRigi;
    [SerializeField] protected bool canPiercing;
    [SerializeField] protected int maxPiercing = 4;
    [SerializeField] protected float reducePiercingPercent = 0.25f;

    protected int piercingTime;
    private Vector2 direction;

    protected override void OnEnable() {
        base.OnEnable();
        if(canPiercing) {
            piercingTime = 0;
            SetAlpha(1);
        }
    }

    public void Shoot(float speed, Vector2 direction, float acceleration = 0f) {
        this.speed = speed;
        transform.up = direction.normalized;
        this.direction = direction.normalized;
        this.accelerationSpeed = acceleration;
    }

    public void Shoot(float speed, Quaternion rotation) {
        this.speed = speed;
        transform.rotation = rotation;
        this.direction = transform.up;
    }

    private void FixedUpdate() {
        myRigi.MovePosition(myRigi.position + direction * speed * Time.fixedDeltaTime);
        speed += accelerationSpeed * Time.fixedDeltaTime;
    }

    protected override bool IsBlockHit() {
        if(canPiercing) {
            return piercingTime >= maxPiercing;
        }
        return isHitted;
    }

    protected override void Hit(Collider2D collision) {
        if (canPiercing) {
            piercingTime++;
            CharacterTakeHit victim = collision.GetComponent<CharacterTakeHit>();
            if (victim != null) {
                float dameReduce = damage * (piercingTime - 1) * reducePiercingPercent;
                int damageTake = (int)(damage - dameReduce);
                SetAlpha(1 - reducePiercingPercent * (piercingTime - 1));
                victim.TakeHitDamege(damageTake);
            }
            if(piercingTime >= maxPiercing) {
                DestroyWithEffect();
            }
        } else {
            isHitted = true;
            GetComponent<Collider2D>().enabled = false;
            CharacterTakeHit victim = collision.GetComponent<CharacterTakeHit>();
            if (victim != null) {
                victim.TakeHitDamege(damage);
            }
            DestroyWithEffect();
        }
    }
}