using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyTakeHit : CharacterTakeHit {

    private EnemyBase enemyBase;
    public EnemyBase EnemyBase {
        get {
            if(enemyBase == null) {
                enemyBase = GetComponent<EnemyBase>();
            }
            return enemyBase;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            PlayerTakeHit takeHit = collider.GetComponent<PlayerTakeHit>();
            if(takeHit) {
                takeHit.TakeHitDamage(EnemyBase.StaterEnemy.Atk.Value);
            }
        }
    }
}
