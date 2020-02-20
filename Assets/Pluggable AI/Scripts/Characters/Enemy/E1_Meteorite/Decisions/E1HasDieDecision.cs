using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E1HasDieDecision", menuName = "PluggableAI/Decision/Enemy/E1/E1HasDie")]
public class E1HasDieDecision : E1Decision {
    protected override bool Decide(StateController<E1Base> controller) {
        return controller.Character.IsDie();
    }
}
