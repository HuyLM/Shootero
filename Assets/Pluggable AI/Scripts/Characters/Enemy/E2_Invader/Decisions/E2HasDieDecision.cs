using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E2HasDieDecision", menuName = "PluggableAI/Decision/Enemy/E2/E2HasDie")]
public class E2HasDieDecision : E2Decision
{
    protected override bool Decide(StateController<E2Base> controller)
    {
        return controller.Character.IsDie();
    }
}
