using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2SpawnAction", menuName = "PluggableAI/Action/Enemy/E2/E2Spawn")]
public class E2SpawnAction : E2Action
{
    public override void Act(StateController<E2Base> controller)
    {
        controller.Character.Spawn();
    }
}
