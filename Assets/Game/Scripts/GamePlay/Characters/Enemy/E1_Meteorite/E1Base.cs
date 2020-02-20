using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Base : EnemyBase
{
    private E1Attack attackerE1;
    public E1Attack AttackerE1
    {
        get
        {
            if(attackerE1 == null)
            {
                attackerE1 = AttackerBase as E1Attack;
            }
            return attackerE1;
        }
    }

    private E1Move moverE1;
    public E1Move MoverE1
    {
        get
        {
            if(moverE1 == null)
            {
                moverE1 = MoverBase as E1Move;
            }
            return moverE1;
        }
    }

    private E1Health healtherE1;
    public E1Health HealtherE1
    {
        get
        {
            if(healtherE1 == null)
            {
                healtherE1 = HealtherBase as E1Health;
            }
            return healtherE1;
        }
    }

    private E1Stat staterE1;
    public E1Stat StaterE1
    {
        get
        {
            if (staterE1 == null)
            {
                staterE1 = StaterBase as E1Stat;
            }
            return staterE1;
        }
    }

    private E1TakeHit takehitterE1;
    public E1TakeHit TakehitterE1
    {
        get
        {
            if (takehitterE1 == null)
            {
                takehitterE1 = TakeHitterBase as E1TakeHit;
            }
            return takehitterE1;
        }
    }
    public override void Countdown() {
        
    }
}
