using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4HasCompleteMoveToTargetDecision", menuName = "PluggableAI/Decision/Enemy/E4/E4HasCompleteMoveToTarget")]
public class E4HasCompleteMoveToTargetDecision : E4Decision
{
    protected override bool Decide(StateController<E4Base> controller)
    {
        return controller.Character.MoverE4.CompleteMoveToTarget();
    }
}

