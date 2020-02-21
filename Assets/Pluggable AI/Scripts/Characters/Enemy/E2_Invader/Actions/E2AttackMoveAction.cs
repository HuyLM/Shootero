using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2AttackMoveAction", menuName = "PluggableAI/Action/Enemy/E2/E2AttackMove")]
public class E2AttackMoveAction : E2Action {
    public override void Act(StateController<E2Base> controller) {
        controller.Character.AttackerE2.AttackMove();
    }
}

