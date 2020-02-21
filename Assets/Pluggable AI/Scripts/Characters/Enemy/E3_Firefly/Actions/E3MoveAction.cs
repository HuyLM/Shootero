using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E3MoveAction", menuName = "PluggableAI/Action/Enemy/E3/E3Move")]
public class E3MoveAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.MoverE3.Move();
    }
}

