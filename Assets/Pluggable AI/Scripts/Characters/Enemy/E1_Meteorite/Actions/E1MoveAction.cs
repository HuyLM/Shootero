using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E1MoveAction", menuName = "PluggableAI/Action/Enemy/E1/E1Move")]
public class E1MoveAction : E1Action {
    public override void Act(StateController<E1Base> controller) {
        //controller.Character.Mover<E1Move, E1Base>().Move();
    }
}
