using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E2MoveAction", menuName = "PluggableAI/Action/Enemy/E2/E2Move")]
public class E2MoveAction : E2Action
{
    public override void Act(StateController<E2Base> controller)
    {
        controller.Character.MoverE2.Move();
    }
}

