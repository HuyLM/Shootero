using UnityEngine;

public class E5Move : EnemyMove {
    [SerializeField] protected AreaType randomArea;

    protected Vector2 GetRandomInArea() {
        return Helper.BorderHelper.GetPoinRandomInArea(randomArea);
    }

    public override void StartMoveAppear() {
        Vector2 pointAppear = GetRandomInArea();
        currentMoveSpeed = appearMoveSpeed;
        targetMove = pointAppear;
        direction = (pointAppear - (Vector2)transform.position).normalized;
        myRigi.MoveRotation(Vector2.SignedAngle(Vector2.up, direction));
    }
}
