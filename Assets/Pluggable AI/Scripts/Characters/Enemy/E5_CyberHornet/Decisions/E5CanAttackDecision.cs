using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5CanAttackDecision", menuName = "PluggableAI/Decision/Enemy/E5/E5CanAttack")]
public class E5CanAttackDecision : E5Decision {
    protected override bool Decide(StateController<E5Base> controller) {
        return controller.Character.AttackerE5.CanAttack();
    }
}


