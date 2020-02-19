using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E1DestroyAction", menuName = "PluggableAI/Action/Enemy/E1/E1Destroy")]
public class E1DestroyAction : E1Action {
    public override void Act(StateController<E1Base> controller) {
        controller.Character.Destroy();
    }
}
