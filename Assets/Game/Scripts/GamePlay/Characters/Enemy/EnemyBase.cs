using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : CharacterBase
{
    [SerializeField] protected AreaType spawnBorderType;
    [SerializeField] protected float spawnBorderOffset = 1;



    public void Spawn() {
        Vector2 positionSpawn = Helper.BorderHelper.GetRandomPositionBorder(spawnBorderType, spawnBorderOffset);
        //EnemyMove<T> mover = Mover<EnemyMove<T>, T>();
        //mover.MyRigi.MovePosition(positionSpawn);
    }

    public override void Die() {
        Debug.Log("die");
    }

    public override void Destroy() {
        Debug.Log("destroy");
    }
}
