using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2CountdownAction", menuName = "PluggableAI/Action/Enemy/E2/E2Countdown")]
public class E2CountdownAction : E2Action {
    public override void Act(StateController<E2Base> controller) {
        controller.Character.Countdown();
    }
}
