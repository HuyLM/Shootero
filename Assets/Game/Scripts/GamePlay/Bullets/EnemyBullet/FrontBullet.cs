using UnityEngine;

public class FrontBullet : BulletBase {
    private float speed;
    private float accelerationSpeed = 0f;
    [SerializeField] protected Rigidbody2D myRigi;

    private Vector2 direction;

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

}