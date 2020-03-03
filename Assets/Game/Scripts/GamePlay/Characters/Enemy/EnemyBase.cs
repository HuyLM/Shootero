using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : CharacterBase {
    [SerializeField] protected EnemyType type;
    [SerializeField] protected AreaType spawnBorderType;
    [SerializeField] protected float spawnBorderOffset = 1;

    Vector2 positionSpawn;


    private EnemyAttack attackerEnemy;
    public EnemyAttack AttackerEnemy {
        get {
            if(attackerEnemy == null) {
                attackerEnemy = GetComponent<EnemyAttack>();
            }
            return attackerEnemy;
        }
    }
    private EnemyMove moverEnemy;
    public EnemyMove MoverEnemy {
        get {
            if(moverEnemy == null) {
                moverEnemy = GetComponent<EnemyMove>();
            }
            return moverEnemy;
        }
    }
    private EnemyHealth healtherEnemy;
    public EnemyHealth HealtherEnemy {
        get {
            if(healtherEnemy == null) {
                healtherEnemy = GetComponent<EnemyHealth>();
            }
            return healtherEnemy;
        }
    }

    private EnemyStat staterEnemy;
    public EnemyStat StaterEnemy {
        get {
            if(staterEnemy == null) {
                staterEnemy = GetComponent<EnemyStat>();
            }
            return staterEnemy;
        }
    }

    private EnemyTakeHit takeHitterEnemy;
    public EnemyTakeHit TakeHitterEnemy {
        get {
            if(takeHitterEnemy == null) {
                takeHitterEnemy = GetComponent<EnemyTakeHit>();
            }
            return takeHitterEnemy;
        }
    }

    private EnemySkill skillerEnemy;
    public EnemySkill SkillerEnemy {
        get {
            if(skillerEnemy == null) {
                skillerEnemy = GetComponent<EnemySkill>();
            }
            return skillerEnemy;
        }
    }

    public EnemyType Type { get => type; }

    public void Spawn() {
        positionSpawn = Helper.BorderHelper.GetRandomPositionBorder(spawnBorderType, spawnBorderOffset);
        transform.position = positionSpawn;
    }

    public override void Die() {
        Debug.Log("die");
        onDie?.Invoke();
        DropItemManager.Instance.SpawnChip(transform.position);
        GameManager.Instance.RemoveEnemy(this);


    }

    public override void Destroy() {
        Debug.Log("destroy");
        GameManager.Instance.RemoveEnemy(this);

    }

}

public enum EnemyType {
    Normal, Elite, Champion
}