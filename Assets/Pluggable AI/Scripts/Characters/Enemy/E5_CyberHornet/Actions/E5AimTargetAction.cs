using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5AimTargetAction", menuName = "PluggableAI/Action/Enemy/E5/E5AimTarget")]
public class E5AimTargetAction : E5Action {
    public override void Act(StateController<E5Base> controller) {
        controller.Character.AttackerE5.AimTarget();
    }
}


