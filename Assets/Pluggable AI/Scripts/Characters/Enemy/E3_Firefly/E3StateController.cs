using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

public class E3StateController : StateController<E3Base> {
    [SerializeField] protected E3State startState;
    [SerializeField] protected E3State remainState;
    [SerializeField] protected E3Action[] alwaysUpdates;
    [SerializeField] protected E3Transition[] transitionsFromAnyState;
    public override State<E3Base> StartState { get => startState; }

    public override State<E3Base> RemainState { get => remainState; }

    public override IEnumerable<Action<E3Base>> AlwaysUpdates { get => alwaysUpdates; }

    public override IEnumerable<Transition<E3Base>> TransitionsFromAnyState { get => transitionsFromAnyState; }

}
