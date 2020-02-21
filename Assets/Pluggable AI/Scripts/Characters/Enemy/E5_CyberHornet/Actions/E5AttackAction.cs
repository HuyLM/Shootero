using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E5AttackAction", menuName = "PluggableAI/Action/Enemy/E5/E5Attack")]
public class E5AttackAction : E5Action {
    public override void Act(StateController<E5Base> controller) {
        controller.Character.AttackerE5.Attack();
    }
}

