using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E6CanMoveAppearDecision", menuName = "PluggableAI/Decision/Enemy/E6/E6CanMoveAppear")]
public class E6CanMoveAppearDecision : E6Decision {
    protected override bool Decide(StateController<E6Base> controller) {
        return true;
    }
}


