using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3DieAction", menuName = "PluggableAI/Action/Enemy/E3/E3Die")]
public class E3DieAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.Die();
    }
}
