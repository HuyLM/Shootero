using UnityEngine;

public abstract class EnemyMove : CharacterMove
{
    [SerializeField] protected AreaType randomArea;
    [SerializeField] protected float appearMoveSpeed =5;
    protected Vector2 direction;
    [SerializeField] protected float currentMoveSpeed;
    [SerializeField] private float speedRotate = 10f;

    protected Vector2 GetRandomInArea() {
        return Helper.BorderHelper.GetPoinRandomInArea(randomArea);
    }

    public virtual void StartMoveAppear() {

    }
    public void Move()
    {
        myRigi.MovePosition(myRigi.position + direction * currentMoveSpeed * Time.deltaTime);
    }

    public virtual bool HasOutBorder()
    {
        int halfW = GamePlayConfig.borderW / 2 + GamePlayConfig.offsetBorder;
        int halfH = GamePlayConfig.borderH / 2 + GamePlayConfig.offsetBorder;
        Vector2 currentPosition = myRigi.position;
        if(currentPosition.x > halfW || currentPosition.x < -halfW)
        {
            return true;
        }
        if (currentPosition.y > halfH || currentPosition.y < -halfH)
        {
            return true;
        }
        return false;
    }

    public void SetDirectionMove(Vector2 dir) {
        this.direction = dir.normalized;
    }

    public virtual void LookDirection(Vector2 direction) {
        MyRigi.MoveRotation(Mathf.LerpAngle(MyRigi.rotation, Vector2.SignedAngle(Vector2.up, direction), Time.deltaTime * speedRotate));
    }

    public virtual void LookTarget(Vector2 target) {
        LookDirection(target - MyRigi.position);
    }

   
}
