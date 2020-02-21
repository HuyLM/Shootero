using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5CountdownAction", menuName = "PluggableAI/Action/Enemy/E5/E5Countdown")]
public class E5CountdownAction : E5Action {
    public override void Act(StateController<E5Base> controller) {
        controller.Character.Countdown();
    }
}
