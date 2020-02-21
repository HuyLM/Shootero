using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E3HasDieDecision", menuName = "PluggableAI/Decision/Enemy/E3/E3HasDie")]
public class E3HasDieDecision : E3Decision {
    protected override bool Decide(StateController<E3Base> controller) {
        return controller.Character.IsDie();
    }
}
