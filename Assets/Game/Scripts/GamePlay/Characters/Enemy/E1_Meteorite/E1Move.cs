using UnityEngine;

public class E1Move : EnemyMove
{
    [SerializeField] private float rotateSpeed = 1;
    private Vector2 direction;
    public override void MoveAppear() {
        Vector2 pointAppear = GetRandomInArea();
        direction = (pointAppear - myRigi.position).normalized;
    }

    public void Move() {
        myRigi.MovePosition(myRigi.position + direction * movingSpeed * Time.deltaTime);
    }

    public void RotateSelf() {
        myRigi.MoveRotation(myRigi.rotation + rotateSpeed * Time.deltaTime);
    }
}
