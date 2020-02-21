using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3CanAttackDecision", menuName = "PluggableAI/Decision/Enemy/E3/E3CanAttack")]
public class E3CanAttackDecision : E3Decision {
    protected override bool Decide(StateController<E3Base> controller) {
        return controller.Character.AttackerE3.CanAttack();
    }
}


