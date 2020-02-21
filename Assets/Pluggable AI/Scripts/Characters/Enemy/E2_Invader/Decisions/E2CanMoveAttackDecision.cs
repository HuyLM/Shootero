using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2CanMoveAttackDecision", menuName = "PluggableAI/Decision/Enemy/E2/E2CanMoveAttack")]
public class E2CanMoveAttackDecision : E2Decision {
    protected override bool Decide(StateController<E2Base> controller) {
        return controller.Character.AttackerE2.CanAttackMove();
    }
}
