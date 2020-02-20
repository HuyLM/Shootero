using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMove : CharacterMove
{
    [SerializeField] protected AreaType randomArea;
    [SerializeField] protected float movingSpeed;
    protected Vector2 direction;

    protected Vector2 GetRandomInArea() {
        return Helper.BorderHelper.GetPoinRandomInArea(randomArea);
    }

    public virtual void StartMoveAppear() {
        Vector2 pointAppear = GetRandomInArea();

    }
    public void Move()
    {
        myRigi.MovePosition(myRigi.position + direction * movingSpeed * Time.deltaTime);
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
}
