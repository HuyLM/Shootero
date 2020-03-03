using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour {

    #region References
    private CharacterAttack attacker;
    public CharacterAttack AttackerBase {
        get {
            if(attacker == null) {
                attacker = GetComponent<CharacterAttack>();
            }
            return attacker;
        }
    }

    private CharacterMove mover;
    public CharacterMove MoverBase {
        get {
            if(mover == null) {
                mover = GetComponent<CharacterMove>();
            }
            return mover;
        }
    }

    private CharacterHealth healther;
    public CharacterHealth HealtherBase {
        get {
            if(healther == null) {
                healther = GetComponent<CharacterHealth>();
            }
            return healther;
        }
    }

    private CharacterStat stater;
    public CharacterStat StaterBase {
        get {
            if(stater == null) {
                stater = GetComponent<CharacterStat>();
            }
            return stater;
        }
    }

    private CharacterTakeHit takeHitter;
    public CharacterTakeHit TakeHitterBase {
        get {
            if(takeHitter == null) {
                takeHitter = GetComponent<CharacterTakeHit>();
            }
            return takeHitter;
        }
    }

    private CharacterSkill skillerBase;
    public CharacterSkill SkillerBase {
        get {
            if(skillerBase == null) {
                skillerBase = GetComponent<CharacterSkill>();
            }
            return skillerBase;
        }
    }

    #endregion

    protected Action onDie;

    public void AddOnDie(Action onDie) {
        this.onDie += onDie;
    }

    public void RemoveOnDie(Action onDie) {
        this.onDie -= onDie;
    }

    public virtual void Initalize() {
        AttackerBase.Initalize();
        MoverBase.Initalize();
        HealtherBase.Initalize();
        StaterBase.Initalize();
        TakeHitterBase.Initalize();
        SkillerBase.Initalize();
    }

    public virtual void Countdown() {
        AttackerBase.Countdown();
        MoverBase.Countdown();
        HealtherBase.Countdown();
        StaterBase.Countdown();
        TakeHitterBase.Countdown();
        SkillerBase.Countdown();
    }

    public abstract void Die();
    public abstract void Destroy();

    public virtual bool IsDie() {
        return HealtherBase.CurrentHp <= 0;
    }
}


