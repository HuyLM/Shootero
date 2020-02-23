using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4StartRotateAttackAction", menuName = "PluggableAI/Action/Enemy/E4/E4StartRotateAttack")]

public class E4StartRotateAttackAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.MoverE4.StartRotateAttack();
    }
}


