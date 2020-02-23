using PluggableAI;
using UnityEngine;


[CreateAssetMenu(fileName = "E4HasDieDecision", menuName = "PluggableAI/Decision/Enemy/E4/E4HasDie")]
public class E4HasDieDecision : E4Decision
{
    protected override bool Decide(StateController<E4Base> controller)
    {
        return controller.Character.IsDie();
    }
}
