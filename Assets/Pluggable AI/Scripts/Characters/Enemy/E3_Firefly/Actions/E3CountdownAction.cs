using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3CountdownAction", menuName = "PluggableAI/Action/Enemy/E3/E3Countdown")]
public class E3CountdownAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.Countdown();
    }
}
