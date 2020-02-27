using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2Move : EnemyMove
{
    [SerializeField] protected AreaType randomArea;
    [SerializeField] private float attackMoveSpeed = 20;

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
        SetDirectionMove(target - myRigi.position);
        LookTarget(target);
    }

}
