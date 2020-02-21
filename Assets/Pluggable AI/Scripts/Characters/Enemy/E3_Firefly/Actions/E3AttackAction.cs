using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E3AttackAction", menuName = "PluggableAI/Action/Enemy/E3/E3Attack")]
public class E3AttackAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.AttackerE3.Attack();
    }
}

