using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerCanDieDecision", menuName = "PluggableAI/Decision/Player/PlayerCanDie")]
public class PlayerCanDieDecision : PlayerDecision {
    protected override bool Decide(StateController<PlayerBase> controller) {
        return controller.Character.IsDie();
    }
}
