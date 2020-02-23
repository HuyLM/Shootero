using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E4MoveAction", menuName = "PluggableAI/Action/Enemy/E4/E4Move")]
public class E4MoveAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.MoverE4.Move();
    }
}

