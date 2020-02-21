using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6DieAction", menuName = "PluggableAI/Action/Enemy/E6/E6Die")]
public class E6DieAction : E6Action {
    public override void Act(StateController<E6Base> controller) {
        controller.Character.Die();
    }
}
