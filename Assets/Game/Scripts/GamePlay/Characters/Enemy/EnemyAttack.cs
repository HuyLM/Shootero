
using UnityEngine;
using System.Collections.Generic;

public abstract class EnemyAttack : CharacterAttack {
    private EnemyBase enemyBase;
    public EnemyBase EnemyBase {
        get {
            if(enemyBase == null) {
                enemyBase = GetComponent<EnemyBase>();
            }
            return enemyBase;
        }
    }

    [SerializeField] private Transform target;

    protected Transform Target {
        get {
            if(target == null) {
                target = GameManager.Instance.GameLoader.Player.transform;
            }
            return target;
        }
    }

    public virtual void Attack() {

    }

    public virtual bool CanAttack() {
        return true;
    }

    protected virtual T ChangeBullet<T>(T bullet) where T : BulletBase {
        T bulletChanged;
        bulletChanged = PoolManager.Spawn(bullet);
        bulletChanged.SetHitInfor(EnemyBase.StaterEnemy.Atk.Value, new List<IEffectAttackModable>(), EnemyBase);
        return bulletChanged;
    }
}
