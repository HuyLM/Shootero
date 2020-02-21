using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5SpawnAction", menuName = "PluggableAI/Action/Enemy/E5/E5Spawn")]
public class E5SpawnAction : E5Action {
    public override void Act(StateController<E5Base> controller) {
        controller.Character.Spawn();
    }
}
