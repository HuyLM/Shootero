using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2Move : EnemyMove
{
    private Vector2 targetMove;
    public override void StartMoveAppear()
    {
        Vector2 pointAppear = GetRandomInArea();
        targetMove = pointAppear;
        direction = (pointAppear - myRigi.position).normalized;
    }

    public bool CompleteMoveToTarget()
    {
        if(targetMove == null)
        {
            return false;
        }
        return Vector2.Distance(targetMove, myRigi.position) < 0.1f;
    }

    public void SetDirectionMove(Vector2 dir)
    {
        direction = dir.normalized;
    }
}
