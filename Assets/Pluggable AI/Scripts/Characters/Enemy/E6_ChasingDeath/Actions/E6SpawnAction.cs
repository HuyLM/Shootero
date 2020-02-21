using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6SpawnAction", menuName = "PluggableAI/Action/Enemy/E6/E6Spawn")]
public class E6SpawnAction : E6Action {
    public override void Act(StateController<E6Base> controller) {
        controller.Character.Spawn();
    }
}
