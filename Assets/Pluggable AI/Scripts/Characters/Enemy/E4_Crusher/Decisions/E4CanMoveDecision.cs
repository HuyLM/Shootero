using PluggableAI;
using UnityEngine;

[CreateAssetMenu(fileName = "E4CanMoveDecision", menuName = "PluggableAI/Decision/Enemy/E4/E4CanMove")]
public class E4CanMoveDecision : E4Decision
{
    protected override bool Decide(StateController<E4Base> controller)
    {
        return true;
    }
}
