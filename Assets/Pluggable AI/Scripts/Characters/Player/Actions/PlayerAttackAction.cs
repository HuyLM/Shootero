using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackAction", menuName = "PluggableAI/Action/Player/PlayerAttack")]
public class PlayerAttackAction : PlayerAction {
    public override void Act(StateController<PlayerBase> controller) {
        controller.Character.AttackerPlayer.Attack();
    }
}

