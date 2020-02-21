using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3IsAttackingDecision", menuName = "PluggableAI/Decision/Enemy/E3/E3IsAttacking")]
public class E3IsAttackingDecision : E3Decision {
    protected override bool Decide(StateController<E3Base> controller) {
        return controller.Character.AttackerE3.IsAttacking();
    }
}
