using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2Attack : EnemyAttack
{

    private E2Base e2Base;
    public E2Base E2Base
    {
        get
        {
            if(e2Base == null)
            {
                e2Base = GetComponent<E2Base>();
            }
            return e2Base;
        }
    }
    [SerializeField] private Transform target;
    public override void Attack()
    {
        base.Attack();
        Debug.Log("e2 attack");
        E2Base.MoverE2.SetDirectionMove((Vector2)target.position - E2Base.MoverE2.MyRigi.position);
    }
}
