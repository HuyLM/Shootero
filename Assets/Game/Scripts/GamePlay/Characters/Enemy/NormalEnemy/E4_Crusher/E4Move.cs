using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4Move : EnemyMove
{
    [SerializeField] protected AreaType randomArea;
    [SerializeField] private float attackMoveSpeed = 20;
    [SerializeField] private float rotateSpeedNormal = 1;
    [SerializeField] private float rotateSpeedAttack = 2;
    private float rotateSpeed;

    protected Vector2 GetRandomInArea() {
        return Helper.BorderHelper.GetPoinRandomInArea(randomArea);
    }

    public override void StartMoveAppear()
    {
        Vector2 pointAppear = GetRandomInArea();
        currentMoveSpeed = appearMoveSpeed;
        targetMove = pointAppear;
        direction = (pointAppear - (Vector2)transform.position).normalized;
        myRigi.MoveRotation(Vector2.SignedAngle(Vector2.up, direction));
    }

    public void SetTargetMoveAttack(Vector2 target)
    {
        currentMoveSpeed = attackMoveSpeed;
        targetMove = target;
        SetDirectionMove(target - myRigi.position);
    }

    public void StartRotateNormal()
    {
        rotateSpeed = rotateSpeedNormal;
    }

    public void StartRotateAttack()
    {
        rotateSpeed = rotateSpeedAttack;
    }
    public void RotateSelf()
    {
        myRigi.MoveRotation(myRigi.rotation + rotateSpeed * Time.deltaTime);
    }
}
