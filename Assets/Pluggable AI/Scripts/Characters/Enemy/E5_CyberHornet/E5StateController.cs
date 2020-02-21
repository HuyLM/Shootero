using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

public class E5StateController : StateController<E5Base> {
    [SerializeField] protected E5State startState;
    [SerializeField] protected E5State remainState;
    [SerializeField] protected E5Action[] alwaysUpdates;
    [SerializeField] protected E5Transition[] transitionsFromAnyState;
    public override State<E5Base> StartState { get => startState; }

    public override State<E5Base> RemainState { get => remainState; }

    public override IEnumerable<Action<E5Base>> AlwaysUpdates { get => alwaysUpdates; }

    public override IEnumerable<Transition<E5Base>> TransitionsFromAnyState { get => transitionsFromAnyState; }

}
