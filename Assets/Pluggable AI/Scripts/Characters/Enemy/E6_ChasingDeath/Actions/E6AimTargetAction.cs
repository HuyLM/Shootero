using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6AimTargetAction", menuName = "PluggableAI/Action/Enemy/E6/E6AimTarget")]
public class E6AimTargetAction : E6Action {
    public override void Act(StateController<E6Base> controller) {
        controller.Character.AttackerE6.AimTarget();
    }
}


