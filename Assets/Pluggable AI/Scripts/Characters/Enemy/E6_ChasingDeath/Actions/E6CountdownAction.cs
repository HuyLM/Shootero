using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6CountdownAction", menuName = "PluggableAI/Action/Enemy/E6/E6Countdown")]
public class E6CountdownAction : E6Action {
    public override void Act(StateController<E6Base> controller) {
        controller.Character.Countdown();
    }
}
