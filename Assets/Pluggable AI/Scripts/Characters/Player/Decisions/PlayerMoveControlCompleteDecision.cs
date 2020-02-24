using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMoveControlCompleteDecision", menuName = "PluggableAI/Decision/Player/PlayerMoveControlComplete")]
public class PlayerMoveControlCompleteDecision : PlayerDecision {
    protected override bool Decide(StateController<PlayerBase> controller) {
        return controller.Character.MoverPlayer.HasMoveControlComplete();
    }
}

