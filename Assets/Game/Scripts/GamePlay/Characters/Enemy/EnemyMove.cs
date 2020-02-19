using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMove : CharacterMove
{
    [SerializeField] protected AreaType randomArea;
    [SerializeField] protected float movingSpeed;

     
    protected Vector2 GetRandomInArea() {
        return Helper.BorderHelper.GetPoinRandomInArea(randomArea);
    }

    public virtual void MoveAppear() {
        Vector2 pointAppear = GetRandomInArea();

    }
}
