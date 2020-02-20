using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E2CanMoveDecision", menuName = "PluggableAI/Decision/Enemy/E2/E2CanMove")]
public class E2CanMoveDecision : E2Decision
{
    protected override bool Decide(StateController<E2Base> controller)
    {
        return true;
    }
}
