using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3StartAppearAction", menuName = "PluggableAI/Action/Enemy/E3/E3StartAppear")]

public class E3StartAppearAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.MoverEnemy.StartMoveAppear();
    }
}
