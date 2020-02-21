using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E6MoveAction", menuName = "PluggableAI/Action/Enemy/E6/E6Move")]
public class E6MoveAction : E6Action {
    public override void Act(StateController<E6Base> controller) {
        controller.Character.MoverE6.Move();
    }
}

