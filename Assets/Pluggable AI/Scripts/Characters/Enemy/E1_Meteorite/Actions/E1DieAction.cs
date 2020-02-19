using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E1DieAction", menuName = "PluggableAI/Action/Enemy/E1/E1Die")]
public class E1DieAction : E1Action {
    public override void Act(StateController<E1Base> controller) {
        controller.Character.Die();
    }
}
