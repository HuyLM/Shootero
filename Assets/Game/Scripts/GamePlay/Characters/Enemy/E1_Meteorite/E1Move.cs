using UnityEngine;

public class E1Move : EnemyMove
{
    [SerializeField] private float rotateSpeed = 1;
    
    public override void StartMoveAppear() {
        Vector2 pointAppear = GetRandomInArea();
        direction = (pointAppear - myRigi.position).normalized;
    }

  

    public void RotateSelf() {
        myRigi.MoveRotation(myRigi.rotation + rotateSpeed * Time.deltaTime);
    }
}
