using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

public class E2StateController : StateController<E2Base>
{
    [SerializeField] protected E2State startState;
    [SerializeField] protected E2State remainState;
    [SerializeField] protected E2Action[] alwaysUpdates;
    [SerializeField] protected E2Transition[] transitionsFromAnyState;
    public override State<E2Base> StartState { get => startState; }

    public override State<E2Base> RemainState { get => remainState; }

    public override IEnumerable<Action<E2Base>> AlwaysUpdates { get => alwaysUpdates; }

    public override IEnumerable<Transition<E2Base>> TransitionsFromAnyState { get => transitionsFromAnyState; }

}
