using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2AimTargetAction", menuName = "PluggableAI/Action/Enemy/E2/E2AimTarget")]
public class E2AimTargetAction : E2Action {
    public override void Act(StateController<E2Base> controller) {
        controller.Character.AttackerE2.AimTarget();
    }
}


