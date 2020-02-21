using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3StartAttackAction", menuName = "PluggableAI/Action/Enemy/E3/E3StartAttack")]
public class E3StartAttackAction : E3Action {
    public override void Act(StateController<E3Base> controller) {
        controller.Character.AttackerE3.StartAttack();
    }
}
