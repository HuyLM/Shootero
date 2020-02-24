using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDieAction", menuName = "PluggableAI/Action/Player/PlayerDie")]
public class PlayerDieAction : PlayerAction {
    public override void Act(StateController<PlayerBase> controller) {
        controller.Character.Die();
    }
}

