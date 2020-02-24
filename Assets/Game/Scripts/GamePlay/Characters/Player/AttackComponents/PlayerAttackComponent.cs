using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttackComponent : MonoBehaviour
{
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float atkSpeed;
    [SerializeField] protected int maxLevel;

    protected bool isAttacking;
    protected float attackCountdown;
    protected int currentLevel = 1;

    public virtual void Initalize() {
        attackCountdown = FireRate;
        isAttacking = false;

    }

    public float FireRate {
        get {
            return 1 / atkSpeed;
        }
    }

    protected virtual void StartAttacking() {
        isAttacking = true;
    }

    protected abstract void Attacking();

    protected virtual void EndAttacking() {
        attackCountdown = FireRate;
        isAttacking = false;
    }

    public void Attack() {
        if(CanAttack()) {
            StartAttacking();
            Attacking();
        }
    }

    protected virtual bool CanAttack() {
        return attackCountdown <= 0 && !isAttacking;
    }

    public virtual void Countdown() {
        if(attackCountdown > 0) {
            attackCountdown -= Time.deltaTime;
        }
    }

    public bool CanUpgrade() {
        return currentLevel < maxLevel;
    }

    public virtual void Upgrade() {
        currentLevel++;
    }
}
