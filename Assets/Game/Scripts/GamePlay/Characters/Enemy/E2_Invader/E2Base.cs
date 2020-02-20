using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2Base : EnemyBase
{
    private E2Attack attackerE2;
    public E2Attack AttackerE2
    {
        get
        {
            if (attackerE2 == null)
            {
                attackerE2 = AttackerBase as E2Attack;
            }
            return attackerE2;
        }
    }

    private E2Move moverE2;
    public E2Move MoverE2
    {
        get
        {
            if (moverE2 == null)
            {
                moverE2 = MoverBase as E2Move;
            }
            return moverE2;
        }
    }

    private E2Health healtherE2;
    public E2Health HealtherE2
    {
        get
        {
            if (healtherE2 == null)
            {
                healtherE2 = HealtherBase as E2Health;
            }
            return healtherE2;
        }
    }

    private E2Stat staterE2;
    public E2Stat StaterE2
    {
        get
        {
            if (staterE2 == null)
            {
                staterE2 = StaterBase as E2Stat;
            }
            return staterE2;
        }
    }

    private E2TakeHit takehitterE2;
    public E2TakeHit TakehitterE2
    {
        get
        {
            if (takehitterE2 == null)
            {
                takehitterE2 = TakeHitterBase as E2TakeHit;
            }
            return takehitterE2;
        }
    }
    public override void Countdown()
    {

    }
}
