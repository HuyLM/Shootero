using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4SpawnAction", menuName = "PluggableAI/Action/Enemy/E4/E4Spawn")]
public class E4SpawnAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.Spawn();
    }
}
