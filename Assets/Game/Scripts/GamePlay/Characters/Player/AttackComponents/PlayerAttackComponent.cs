using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttackComponent : MonoBehaviour {
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected float atkSpeed;

    protected PlayerAttack playerAttack;
    protected bool isAttacking;
    protected float attackCountdown;
    protected FloatStat playerAtkSpeed;

    public void SetPlayerAttack(PlayerAttack playerAttack) {
        this.playerAttack = playerAttack;
    }

    public virtual void Initalize() {
        isAttacking = false;
        playerAtkSpeed = playerAttack.PlayerBase.StaterPlayer.AtkSpeed;
        playerAtkSpeed.BaseValue = atkSpeed;
        attackCountdown = FireRate;

    }

    public float FireRate {
        get {
            return 1 / playerAtkSpeed.Value;
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

    public virtual void Upgrade() {
    }

    public abstract void FocusUpgrade();

    protected virtual T ChangeBullet<T>(T bullet) where T : BulletBase {
        T bulletChanged;

        bulletChanged = PoolManager.Spawn(bullet);
        bulletChanged.SetHitInfor(playerAttack.PlayerBase.StaterPlayer.Atk.Value, playerAttack.PlayerBase.SkillerPlayer.EffectAttackMods, playerAttack.PlayerBase);
        foreach(var mod in playerAttack.PlayerBase.SkillerPlayer.ChangeBulletMods) {
            mod.ChangeBullet(bulletChanged.GetComponent<T>());
        }

        return bulletChanged;
    }
}
