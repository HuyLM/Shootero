using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5DieAction", menuName = "PluggableAI/Action/Enemy/E5/E5Die")]
public class E5DieAction : E5Action {
    public override void Act(StateController<E5Base> controller) {
        controller.Character.Die();
    }
}
