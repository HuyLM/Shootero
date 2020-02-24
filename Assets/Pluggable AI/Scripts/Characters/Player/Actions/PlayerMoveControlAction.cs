using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveControlAction", menuName = "PluggableAI/Action/Player/PlayerMoveControl")]
public class PlayerMoveControlAction : PlayerAction {
    public override void Act(StateController<PlayerBase> controller) {
        controller.Character.MoverPlayer.MoveControl();
    }
}

