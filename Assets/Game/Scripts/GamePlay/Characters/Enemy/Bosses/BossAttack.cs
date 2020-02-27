using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : EnemyAttack {
    private BossBase bossBase;
    public BossBase BossBase {
        get {
            if(bossBase == null) {
                bossBase = GetComponent<BossBase>();
            }
            return bossBase;
        }
    }

    [SerializeField] protected List<BossAttackComponent> attackComponents = new List<BossAttackComponent>();
    [SerializeField] protected BossAttackComponent rageAttack;
    [SerializeField] protected 

    private int currentAttackIndex;

    protected void OnEnable() {
        foreach(var attack in attackComponents) {
            attack.Initalize(BossBase);
            attack.AddOnEndAttack(ChangeAttackComponent);
            attack.AddDisableAttack(RemoveAttackComponent);
        }
        rageAttack.AddOnEndAttack(ChangeAttackComponent);
        rageAttack.AddDisableAttack(RemoveAttackComponent);

    }

    protected void OnDisable() {
        foreach(var attack in attackComponents) {
            attack.RemoveEndAttack(ChangeAttackComponent);
            attack.RemoveDisableAttack(RemoveAttackComponent);
        }
        rageAttack.RemoveEndAttack(ChangeAttackComponent);
        rageAttack.RemoveDisableAttack(RemoveAttackComponent);
    }

    protected void ChangeAttackComponent() {
        currentAttackIndex = Random.Range(0, attackComponents.Count);
    }

    public override void Attack() {
        base.Attack();
        attackComponents[currentAttackIndex].Attack();
    }

    public void RageAttack() {
        if(rageAttack) {
            rageAttack.Attack();
        }
    }

    protected virtual void RemoveAttackComponent(BossAttackComponent attackComponent) {
        attackComponents.Remove(attackComponent);
        if(rageAttack == attackComponent) {
            rageAttack = null;
        }
    }
}

