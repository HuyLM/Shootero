using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E3CanMoveAppearDecision", menuName = "PluggableAI/Decision/Enemy/E3/E3CanMoveAppear")]
public class E3CanMoveAppearDecision : E3Decision {
    protected override bool Decide(StateController<E3Base> controller) {
        return true;
    }
}


