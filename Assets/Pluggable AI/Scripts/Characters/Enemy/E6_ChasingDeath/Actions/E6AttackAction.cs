using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E6AttackAction", menuName = "PluggableAI/Action/Enemy/E6/E6Attack")]
public class E6AttackAction : E6Action {
    public override void Act(StateController<E6Base> controller) {
        controller.Character.AttackerE6.Attack();
    }
}

