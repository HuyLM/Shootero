using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5HasCompleteMoveToTargetDecision", menuName = "PluggableAI/Decision/Enemy/E5/E5HasCompleteMoveToTarget")]
public class E5HasCompleteMoveToTargetDecision : E5Decision {
    protected override bool Decide(StateController<E5Base> controller) {
        return controller.Character.MoverE5.CompleteMoveToTarget();
    }
}

