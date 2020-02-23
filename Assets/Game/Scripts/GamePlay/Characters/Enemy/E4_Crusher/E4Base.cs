using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4Base : EnemyBase
{
    private E4Attack attackerE4;
    public E4Attack AttackerE4
    {
        get
        {
            if (attackerE4 == null)
            {
                attackerE4 = AttackerBase as E4Attack;
            }
            return attackerE4;
        }
    }

    private E4Move moverE4;
    public E4Move MoverE4
    {
        get
        {
            if (moverE4 == null)
            {
                moverE4 = MoverBase as E4Move;
            }
            return moverE4;
        }
    }

    private E4Health healtherE4;
    public E4Health HealtherE4
    {
        get
        {
            if (healtherE4 == null)
            {
                healtherE4 = HealtherBase as E4Health;
            }
            return healtherE4;
        }
    }

    private E4Stat staterE4;
    public E4Stat StaterE4
    {
        get
        {
            if (staterE4 == null)
            {
                staterE4 = StaterBase as E4Stat;
            }
            return staterE4;
        }
    }

    private E4TakeHit takehitterE4;
    public E4TakeHit TakehitterE4
    {
        get
        {
            if (takehitterE4 == null)
            {
                takehitterE4 = TakeHitterBase as E4TakeHit;
            }
            return takehitterE4;
        }
    }
}
