using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : CharacterBase
{
    [SerializeField] protected AreaType spawnBorderType;
    [SerializeField] protected float spawnBorderOffset = 1;

    private EnemyAttack attackerEnemy;
    public EnemyAttack AttackerEnemy
    {
        get
        {
            if(attackerEnemy == null)
            {
                attackerEnemy = AttackerBase as EnemyAttack;
            }
            return attackerEnemy;
        }
    }
    private EnemyMove moverEnemy;
    public EnemyMove MoverEnemy
    {
        get
        {
            if (moverEnemy == null)
            {
                moverEnemy = MoverBase as EnemyMove;
            }
            return moverEnemy;
        }
    }
    private EnemyHealth healtherEnemy;
    public EnemyHealth HealtherEnemy
    {
        get
        {
            if (healtherEnemy == null)
            {
                healtherEnemy = HealtherBase as EnemyHealth;
            }
            return healtherEnemy;
        }
    }

    private EnemyStat staterEnemy;
    public EnemyStat StaterEnemy
    {
        get
        {
            if (staterEnemy == null)
            {
                staterEnemy = StaterBase as EnemyStat;
            }
            return staterEnemy;
        }
    }

    private EnemyTakeHit takeHitterEnemy;
    public EnemyTakeHit TakeHitterEnemy
    {
        get
        {
            if (takeHitterEnemy == null)
            {
                takeHitterEnemy = TakeHitterBase as EnemyTakeHit;
            }
            return takeHitterEnemy;
        }
    }


    public void Spawn() {
        Vector2 positionSpawn = Helper.BorderHelper.GetRandomPositionBorder(spawnBorderType, spawnBorderOffset);
        MoverEnemy.MyRigi.MovePosition(positionSpawn);
    }

    public override void Die() {
        Debug.Log("die");
    }

    public override void Destroy() {
        Debug.Log("destroy");
    }
}
