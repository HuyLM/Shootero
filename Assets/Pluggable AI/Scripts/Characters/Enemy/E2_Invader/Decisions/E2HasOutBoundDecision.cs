using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E2HasOutBoundDecision", menuName = "PluggableAI/Decision/Enemy/E2/E2HasOutBound")]
public class E2HasOutBoundDecision : E2Decision
{
    protected override bool Decide(StateController<E2Base> controller)
    {
        return controller.Character.MoverEnemy.HasOutBorder();
    }
}

