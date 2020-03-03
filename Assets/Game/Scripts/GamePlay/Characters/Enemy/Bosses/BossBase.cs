using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBase : EnemyBase {
    [SerializeField] private PartBossBase[] parts;

    #region Boss Component
    private BossAttack attackerBoss;
    public BossAttack AttackerBoss {
        get {
            if(attackerBoss == null) {
                attackerBoss = GetComponent<BossAttack>();
            }
            return attackerBoss;
        }
    }
    private BossMove moverBoss;
    public BossMove MoverBoss {
        get {
            if(moverBoss == null) {
                moverBoss = GetComponent<BossMove>();
            }
            return moverBoss;
        }
    }
    private BossHealth healtherBoss;
    public BossHealth HealtherBoss {
        get {
            if(healtherBoss == null) {
                healtherBoss = GetComponent<BossHealth>();
            }
            return healtherBoss;
        }
    }
    private BossStat staterBoss;
    public BossStat StaterBoss {
        get {
            if(staterBoss == null) {
                staterBoss = GetComponent<BossStat>();
            }
            return staterBoss;
        }
    }
    private BossTakeHit takeHitterBoss;
    public BossTakeHit TakeHitterBoss {
        get {
            if(takeHitterBoss == null) {
                takeHitterBoss = GetComponent<BossTakeHit>();
            }
            return takeHitterBoss;
        }
    }
    private BossSkill skillerBoss;
    public BossSkill SkillerBoss {
        get {
            if(skillerBoss == null) {
                skillerBoss = GetComponent<BossSkill>();
            }
            return skillerBoss;
        }
    }
    #endregion

    protected void OnEnable() {
        foreach(var part in parts) {
            part.HealtherPartBoss.AddOnHpChanged(OnHpChanged);
        }
    }

    protected void OnDisable() {
        foreach(var part in parts) {
            part.HealtherPartBoss.RemoveOnHpChanged(OnHpChanged);
        }
    }

    private void OnHpChanged(int hp, float pct) {
        UpdateHp();
    }

    private void UpdateHp() {
        int sumHp = 0;
        foreach(var part in parts) {
            if(part.IsActiving) {
                sumHp += part.HealtherPartBoss.CurrentHp;
            }
        }
        HealtherBoss.ForceChangeCurrentHp(sumHp);
    }
}
