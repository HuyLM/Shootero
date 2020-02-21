using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E5HasDieDecision", menuName = "PluggableAI/Decision/Enemy/E5/E5HasDie")]
public class E5HasDieDecision : E5Decision {
    protected override bool Decide(StateController<E5Base> controller) {
        return controller.Character.IsDie();
    }
}
