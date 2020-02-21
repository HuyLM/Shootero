using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6HasCompleteMoveToTargetDecision", menuName = "PluggableAI/Decision/Enemy/E6/E6HasCompleteMoveToTarget")]
public class E6HasCompleteMoveToTargetDecision : E6Decision {
    protected override bool Decide(StateController<E6Base> controller) {
        return controller.Character.MoverE6.CompleteMoveToTarget();
    }
}

