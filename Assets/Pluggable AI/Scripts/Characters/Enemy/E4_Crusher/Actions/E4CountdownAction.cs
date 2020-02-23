using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4CountdownAction", menuName = "PluggableAI/Action/Enemy/E4/E4Countdown")]
public class E4CountdownAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.Countdown();
    }
}
