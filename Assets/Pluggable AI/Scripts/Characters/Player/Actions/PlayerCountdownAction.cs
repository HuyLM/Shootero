using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCountdownAction", menuName = "PluggableAI/Action/Player/PlayerCountdown")]
public class PlayerCountdownAction : PlayerAction {
    public override void Act(StateController<PlayerBase> controller) {
        controller.Character.Countdown();
    }
}

