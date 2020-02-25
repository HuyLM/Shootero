using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour {

    #region References
    private CharacterAttack attacker;
    public CharacterAttack AttackerBase
    {
        get
        {
            if(attacker == null)
            {
                attacker = GetComponent<CharacterAttack>();
            }
            return attacker;
        }
    }

    private CharacterMove mover;
    public CharacterMove MoverBase
    {
        get
        {
            if (mover == null)
            {
                mover = GetComponent<CharacterMove>();
            }
            return mover;
        }
    }

    private CharacterHealth healther;
    public CharacterHealth HealtherBase
    {
        get
        {
            if (healther == null)
            {
                healther = GetComponent<CharacterHealth>();
            }
            return healther;
        }
    }

    private CharacterStat stater;
    public CharacterStat StaterBase
    {
        get
        {
            if (stater == null)
            {
                stater = GetComponent<CharacterStat>();
            }
            return stater;
        }
    }

    private CharacterTakeHit takeHitter;
    public CharacterTakeHit TakeHitterBase
    {
        get
        {
            if (takeHitter == null)
            {
                takeHitter = GetComponent<CharacterTakeHit>();
            }
            return takeHitter;
        }
    }

    #endregion

    private void Awake() {
        Initalize();
    }

    public virtual void Initalize() {
        AttackerBase.Initalize();
        MoverBase.Initalize();
        HealtherBase.Initalize();
        StaterBase.Initalize();
        TakeHitterBase.Initalize();
    }

    public virtual void Countdown(){
        AttackerBase.Countdown();
        MoverBase.Countdown();
        HealtherBase.Countdown();
        StaterBase.Countdown();
        TakeHitterBase.Countdown();
    }

    public abstract void Die();
    public abstract void Destroy();

    public virtual bool IsDie()
    {
        return HealtherBase.CurrentHp <= 0;
    }
}


