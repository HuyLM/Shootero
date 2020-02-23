using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4AttackMoveAction", menuName = "PluggableAI/Action/Enemy/E4/E4AttackMove")]
public class E4AttackMoveAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.AttackerE4.AttackMove();
    }
}

