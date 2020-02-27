using UnityEngine;

public abstract class EnemyMove : CharacterMove
{
   
    [SerializeField] protected float appearMoveSpeed =5;
    [SerializeField] protected float currentMoveSpeed;
    [SerializeField] private float speedRotate = 10f;

    protected Vector2 targetMove;
    protected Vector2 direction;


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

    public bool CompleteMoveToTarget() {
        if(targetMove == null) {
            return false;
        }

        return Vector2.Distance(targetMove, myRigi.position) < 0.01f * currentMoveSpeed;
    }

}
