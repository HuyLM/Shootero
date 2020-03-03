using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E2Attack : EnemyAttack {
    private E2Base e2Base;
    public E2Base E2Base {
        get {
            if(e2Base == null) {
                e2Base = GetComponent<E2Base>();
            }
            return e2Base;
        }
    }
    [SerializeField] private float aimTime;
    private float aimCountdown;

    public void StartAimTarget() {
        aimCountdown = aimTime;
    }

    public void AttackMove() {
        E2Base.MoverE2.SetTargetMoveAttack((Vector2)Target.position);
        aimCountdown = aimTime;
    }

    public bool CanAttackMove() {
        return aimCountdown < 0;
    }

    public override void Countdown() {
        base.Countdown();
        if(aimCountdown >= 0) {
            aimCountdown -= Time.deltaTime;
        }
    }

    public void AimTarget() {
        E2Base.MoverE2.LookTarget(Target.position);
    }
}
