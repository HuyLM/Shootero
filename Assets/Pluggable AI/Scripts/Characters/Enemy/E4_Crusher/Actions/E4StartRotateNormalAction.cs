using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4StartRotateNormalAction", menuName = "PluggableAI/Action/Enemy/E4/E4StartRotateNormal")]

public class E4StartRotateNormalAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.MoverE4.StartRotateNormal();
    }
}

