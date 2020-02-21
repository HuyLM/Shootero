using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6IsAttackingDecision", menuName = "PluggableAI/Decision/Enemy/E6/E6IsAttacking")]
public class E6IsAttackingDecision : E6Decision {
    protected override bool Decide(StateController<E6Base> controller) {
        return controller.Character.AttackerE6.IsAttacking();
    }
}
