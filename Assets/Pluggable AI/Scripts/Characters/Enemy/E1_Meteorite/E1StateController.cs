using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

public class E1StateController : StateController<E1Base> {
    [SerializeField] protected E1State startState;
    [SerializeField] protected E1State remainState;
    [SerializeField] protected E1Action[] alwaysUpdates;
    [SerializeField] protected E1Transition[] transitionsFromAnyState;
    public override State<E1Base> StartState { get => startState; }

    public override State<E1Base> RemainState { get => remainState; }

    public override IEnumerable<Action<E1Base>> AlwaysUpdates { get => alwaysUpdates; }

    public override IEnumerable<Transition<E1Base>> TransitionsFromAnyState { get => transitionsFromAnyState; }

}
