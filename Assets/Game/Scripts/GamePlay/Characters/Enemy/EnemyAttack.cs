using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : CharacterAttack
{
    private EnemyBase enemyBase;
    public EnemyBase EnemyBase
    {
        get
        {
            if(enemyBase == null)
            {
                enemyBase = CharacterBase as EnemyBase;
            }
            return enemyBase;
        }
    }
    public virtual void Attack()
    {

    }

    public virtual bool CanAttack()
    {
        return true;
    }
}
