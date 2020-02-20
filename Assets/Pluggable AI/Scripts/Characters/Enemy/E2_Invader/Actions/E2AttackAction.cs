using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2AttackAction", menuName = "PluggableAI/Action/Enemy/E2/E2Attack")]
public class E2AttackAction : E2Action
{
    public override void Act(StateController<E2Base> controller)
    {
        controller.Character.AttackerEnemy.Attack();
    }
}

