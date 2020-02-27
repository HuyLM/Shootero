using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossAttackComponent : MonoBehaviour {
    protected bool isAttacking;
    //protected bool isActiving;
    protected Action onEndAttack;
    protected Action<BossAttackComponent> onDisableAttack;
    
    [SerializeField] protected PartBossBase[] influenceParts;
    [SerializeField] protected float delayAttack;
    //public bool IsActiving { get => isActiving; }
    protected BossBase bossBase;
    protected float countdownDelayAttack;

    public void AddOnEndAttack(Action onEndAttack) {
        this.onEndAttack += onEndAttack;
    }

    public void RemoveEndAttack(Action onEndAttack) {
        this.onEndAttack -= onEndAttack;
    }

    public void AddDisableAttack(Action<BossAttackComponent> onDisableAttack) {
        this.onDisableAttack += onDisableAttack;
    }

    public void RemoveDisableAttack(Action<BossAttackComponent> onDisableAttack) {
        this.onDisableAttack -= onDisableAttack;
    }

    public virtual void Initalize(BossBase bossBase) {
        //isActiving = true;
        this.bossBase = bossBase;
        foreach(var part in influenceParts) {
            part.AddOnDie(Shutdown);
        }
        isAttacking = false;
        countdownDelayAttack = delayAttack;
    }

    protected virtual void StartAttacking() {
        isAttacking = true;
    }

    protected abstract void Attacking();

    protected virtual void EndAttacking() {
        isAttacking = false;
        countdownDelayAttack = delayAttack;
        onEndAttack?.Invoke();
    }

    public void Attack() {
        if(CanAttack()) {
            StartAttacking();
            Attacking();
        }
    }

    protected virtual bool CanAttack() {
        return countdownDelayAttack <= 0 && !isAttacking;
    }

    protected virtual void Shutdown() {
        //isActiving = false;
        onDisableAttack?.Invoke(this);
    }

    public virtual void Countdown() {
        if(countdownDelayAttack > 0) {
            countdownDelayAttack -= Time.deltaTime;
        }
    }
}
