using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E6HasDieDecision", menuName = "PluggableAI/Decision/Enemy/E6/E6HasDie")]
public class E6HasDieDecision : E6Decision {
    protected override bool Decide(StateController<E6Base> controller) {
        return controller.Character.IsDie();
    }
}
