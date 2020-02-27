using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBossBase : EnemyBase {

    private bool isActiving;

    public bool IsActiving { get => isActiving; }

    private PartBossHealth healtherPartBoss;
    public PartBossHealth HealtherPartBoss {
        get {
            if(healtherPartBoss == null) {
                healtherPartBoss = GetComponent<PartBossHealth>();
            }
            return healtherPartBoss;
        }
    }

    private PartBossTakeHit takeHitterPartBoss;
    public PartBossTakeHit TakeHitterPartBoss {
        get {
            if(takeHitterPartBoss == null) {
                takeHitterPartBoss = GetComponent<PartBossTakeHit>();
            }
            return takeHitterPartBoss;
        }
    }

    private PartBossSkill skillerPartBoss;
    public PartBossSkill SkillerPartBoss {
        get {
            if(skillerPartBoss == null) {
                skillerPartBoss = GetComponent<PartBossSkill>();
            }
            return skillerPartBoss;
        }
    }

    public override void Die() {
        base.Die();
        isActiving = false;
        gameObject.SetActive(false);
    }
}
