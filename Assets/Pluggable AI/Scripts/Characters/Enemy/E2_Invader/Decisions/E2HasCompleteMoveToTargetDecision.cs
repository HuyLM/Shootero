using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2HasCompleteMoveToTargetDecision", menuName = "PluggableAI/Decision/Enemy/E2/E2HasCompleteMoveToTarget")]
public class E2HasCompleteMoveToTargetDecision : E2Decision
{
    protected override bool Decide(StateController<E2Base> controller)
    {
        return controller.Character.MoverE2.CompleteMoveToTarget();
    }
}

