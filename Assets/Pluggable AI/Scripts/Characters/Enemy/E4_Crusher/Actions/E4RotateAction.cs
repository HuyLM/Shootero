using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4RotateAction", menuName = "PluggableAI/Action/Enemy/E4/E4Rotate")]
public class E4RotateAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.MoverE4.RotateSelf();
    }
}
