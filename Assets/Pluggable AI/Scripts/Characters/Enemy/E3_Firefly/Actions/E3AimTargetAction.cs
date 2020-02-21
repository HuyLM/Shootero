using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3AimTargetAction", menuName = "PluggableAI/Action/Enemy/E3/E3AimTarget")]
public class E3AimTargetAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.AttackerE3.AimTarget();
    }
}


