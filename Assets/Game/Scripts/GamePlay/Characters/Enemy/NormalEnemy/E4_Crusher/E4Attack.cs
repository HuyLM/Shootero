using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E4Attack : EnemyAttack {
    private E4Base e4Base;
    public E4Base E4Base {
        get {
            if(e4Base == null) {
                e4Base = GetComponent<E4Base>();
            }
            return e4Base;
        }
    }


    public void AttackMove() {
        E4Base.MoverE4.SetTargetMoveAttack((Vector2)Target.position);
    }

    public bool CanAttackMove() {
        return true;
    }

    public override void Countdown() {
        base.Countdown();
    }

}
