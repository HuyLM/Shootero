using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2Move : EnemyMove
{
    [SerializeField] private float attackMoveSpeed = 20;
    private Vector2 targetMove;

    public override void StartMoveAppear()
    {
        Vector2 pointAppear = GetRandomInArea();
        currentMoveSpeed = appearMoveSpeed;
        targetMove = pointAppear;
        direction = (pointAppear - (Vector2)transform.position).normalized;
        myRigi.MoveRotation(Vector2.SignedAngle(Vector2.up, direction));
    }

    public bool CompleteMoveToTarget()
    {
        if(targetMove == null)
        {
            return false;
        }

        return Vector2.Distance(targetMove, myRigi.position) < 0.01f * currentMoveSpeed;
    }

    public void SetTargetMoveAttack(Vector2 target)
    {
        currentMoveSpeed = attackMoveSpeed;
        SetDirectionMove(target - myRigi.position);
        LookTarget(target);
    }

}
