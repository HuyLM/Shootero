using UnityEngine;

public class E1Move : EnemyMove
{
    [SerializeField] protected AreaType randomArea;
    [SerializeField] private float rotateSpeed = 1;

    protected Vector2 GetRandomInArea() {
        return Helper.BorderHelper.GetPoinRandomInArea(randomArea);
    }

    public override void StartMoveAppear() {
        currentMoveSpeed = appearMoveSpeed;
        Vector2 pointAppear = GetRandomInArea();
        direction = (pointAppear - myRigi.position).normalized;
    }

    public void RotateSelf() {
        myRigi.MoveRotation(myRigi.rotation + rotateSpeed * Time.deltaTime);
    }
}
