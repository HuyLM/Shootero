using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4DieAction", menuName = "PluggableAI/Action/Enemy/E4/E4Die")]
public class E4DieAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.Die();
    }
}
