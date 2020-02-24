using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCanMoveControlDecision", menuName = "PluggableAI/Decision/Player/PlayerCanMoveControl")]
public class PlayerCanMoveControlDecision : PlayerDecision {
    protected override bool Decide(StateController<PlayerBase> controller) {
        return controller.Character.MoverPlayer.CanMoveControl();
    }
}
