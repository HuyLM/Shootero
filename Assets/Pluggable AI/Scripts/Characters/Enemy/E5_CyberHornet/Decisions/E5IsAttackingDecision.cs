using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5IsAttackingDecision", menuName = "PluggableAI/Decision/Enemy/E5/E5IsAttacking")]
public class E5IsAttackingDecision : E5Decision {
    protected override bool Decide(StateController<E5Base> controller) {
        return controller.Character.AttackerE5.IsAttacking();
    }
}
