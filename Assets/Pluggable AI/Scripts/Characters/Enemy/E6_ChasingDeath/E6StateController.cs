using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

public class E6StateController : StateController<E6Base> {
    [SerializeField] protected E6State startState;
    [SerializeField] protected E6State remainState;
    [SerializeField] protected E6Action[] alwaysUpdates;
    [SerializeField] protected E6Transition[] transitionsFromAnyState;
    public override State<E6Base> StartState { get => startState; }

    public override State<E6Base> RemainState { get => remainState; }

    public override IEnumerable<Action<E6Base>> AlwaysUpdates { get => alwaysUpdates; }

    public override IEnumerable<Transition<E6Base>> TransitionsFromAnyState { get => transitionsFromAnyState; }

}
