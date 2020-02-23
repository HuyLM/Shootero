using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4CanMoveAttackDecision", menuName = "PluggableAI/Decision/Enemy/E4/E4CanMoveAttack")]
public class E4CanMoveAttackDecision : E4Decision
{
    protected override bool Decide(StateController<E4Base> controller)
    {
        return controller.Character.AttackerE4.CanAttackMove();
    }
}
