using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E1RotateAction", menuName = "PluggableAI/Action/Enemy/E1/E1Rotate")]
public class E1RotateAction : E1Action {
    public override void Act(StateController<E1Base> controller) {
        //controller.Character.Mover<E1Move, E1Base>().RotateSelf();
    }
}
