
using UnityEngine;

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
}
