using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2StartAimAcion", menuName = "PluggableAI/Action/Enemy/E2/E2StartAim")]
public class E2StartAimAcion : E2Action {
    public override void Act(StateController<E2Base> controller) {
        controller.Character.AttackerE2.StartAimTarget();
    }
}
