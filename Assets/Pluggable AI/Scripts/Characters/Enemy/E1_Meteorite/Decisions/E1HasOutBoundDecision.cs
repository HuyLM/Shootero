using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E1HasOutBoundDecision", menuName = "PluggableAI/Decision/Enemy/E1/E1HasOutBound")]
public class E1HasOutBoundDecision : E1Decision {
    protected override bool Decide(StateController<E1Base> controller) {
        return false;
    }
}

