using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E5MoveAction", menuName = "PluggableAI/Action/Enemy/E5/E5Move")]
public class E5MoveAction : E5Action {
    public override void Act(StateController<E5Base> controller) {
        controller.Character.MoverE5.Move();
    }
}

