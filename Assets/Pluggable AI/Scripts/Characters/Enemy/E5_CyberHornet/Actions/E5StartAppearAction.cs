using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5StartAppearAction", menuName = "PluggableAI/Action/Enemy/E5/E5StartAppear")]

public class E5StartAppearAction : E5Action {
    public override void Act(StateController<E5Base> controller) {
        controller.Character.MoverE5.StartMoveAppear();
    }
}
