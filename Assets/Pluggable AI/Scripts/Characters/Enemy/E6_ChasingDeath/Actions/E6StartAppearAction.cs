using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6StartAppearAction", menuName = "PluggableAI/Action/Enemy/E6/E6StartAppear")]

public class E6StartAppearAction : E6Action {
    public override void Act(StateController<E6Base> controller) {
        controller.Character.MoverE6.StartMoveAppear();
    }
}
