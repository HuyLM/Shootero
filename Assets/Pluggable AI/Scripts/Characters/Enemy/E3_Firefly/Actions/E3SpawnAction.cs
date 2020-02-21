using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3SpawnAction", menuName = "PluggableAI/Action/Enemy/E3/E3Spawn")]
public class E3SpawnAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.Spawn();
    }
}
