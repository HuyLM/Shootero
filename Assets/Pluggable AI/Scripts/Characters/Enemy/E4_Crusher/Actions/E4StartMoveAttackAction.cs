using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4StartMoveAttackAction", menuName = "PluggableAI/Action/Enemy/E4/E4StartMoveAttack")]

public class E4StartMoveAttackAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.MoverE4.StartRotateAttack();
    }
}

