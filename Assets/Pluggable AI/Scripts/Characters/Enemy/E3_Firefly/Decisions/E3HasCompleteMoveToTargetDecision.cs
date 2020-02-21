using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3HasCompleteMoveToTargetDecision", menuName = "PluggableAI/Decision/Enemy/E3/E3HasCompleteMoveToTarget")]
public class E3HasCompleteMoveToTargetDecision : E3Decision {
    protected override bool Decide(StateController<E3Base> controller) {
        return controller.Character.MoverE3.CompleteMoveToTarget();
    }
}

