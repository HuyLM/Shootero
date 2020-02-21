using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6CanAttackDecision", menuName = "PluggableAI/Decision/Enemy/E6/E6CanAttack")]
public class E6CanAttackDecision : E6Decision {
    protected override bool Decide(StateController<E6Base> controller) {
        return controller.Character.AttackerE6.CanAttack();
    }
}


