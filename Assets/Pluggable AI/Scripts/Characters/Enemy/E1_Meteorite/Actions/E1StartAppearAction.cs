using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E1StartAppearAction", menuName = "PluggableAI/Action/Enemy/E1/E1StartAppear")]
public class E1StartAppearAction : E1Action {
    public override void Act(StateController<E1Base> controller) {
        controller.Character.MoverEnemy.StartMoveAppear();
    }
}
