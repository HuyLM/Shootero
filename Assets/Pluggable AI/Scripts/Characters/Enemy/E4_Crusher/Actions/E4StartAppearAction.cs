using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4StartAppearAction", menuName = "PluggableAI/Action/Enemy/E4/E4StartAppear")]

public class E4StartAppearAction : E4Action
{
    public override void Act(StateController<E4Base> controller)
    {
        controller.Character.MoverEnemy.StartMoveAppear();
    }
}
