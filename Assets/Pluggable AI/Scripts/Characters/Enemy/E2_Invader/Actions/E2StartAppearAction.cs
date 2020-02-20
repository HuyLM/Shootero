using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2StartAppearAction", menuName = "PluggableAI/Action/Enemy/E2/E2StartAppear")]

public class E2StartAppearAction : E2Action
{
    public override void Act(StateController<E2Base> controller)
    {
        controller.Character.MoverEnemy.StartMoveAppear();
    }
}
