using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E1SpawnAction", menuName = "PluggableAI/Action/Enemy/E1/E1Spawn")]
public class E1SpawnAction : E1Action {
    public override void Act(StateController<E1Base> controller) {
        controller.Character.Spawn();
    }
}
