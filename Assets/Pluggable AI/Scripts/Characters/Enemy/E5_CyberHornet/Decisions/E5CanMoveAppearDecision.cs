using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E5CanMoveAppearDecision", menuName = "PluggableAI/Decision/Enemy/E5/E5CanMoveAppear")]
public class E5CanMoveAppearDecision : E5Decision {
    protected override bool Decide(StateController<E5Base> controller) {
        return true;
    }
}


