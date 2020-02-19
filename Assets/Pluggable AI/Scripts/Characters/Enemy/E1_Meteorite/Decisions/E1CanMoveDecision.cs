using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E1CanMoveDecision", menuName = "PluggableAI/Decision/Enemy/E1/E1CanMove")]
public class E1CanMoveDecision : E1Decision {
    protected override bool Decide(StateController<E1Base> controller) {
        return true;
    }
}
