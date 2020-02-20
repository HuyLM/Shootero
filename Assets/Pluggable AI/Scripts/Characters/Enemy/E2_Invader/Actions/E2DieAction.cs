using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2DieAction", menuName = "PluggableAI/Action/Enemy/E2/E2Die")]
public class E2DieAction : E2Action
{
    public override void Act(StateController<E2Base> controller)
    {
        controller.Character.Die();
    }
}
