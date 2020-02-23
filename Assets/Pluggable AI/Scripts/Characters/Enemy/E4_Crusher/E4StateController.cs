using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

public class E4StateController : StateController<E4Base>
{
    [SerializeField] protected E4State startState;
    [SerializeField] protected E4State remainState;
    [SerializeField] protected E4Action[] alwaysUpdates;
    [SerializeField] protected E4Transition[] transitionsFromAnyState;
    public override State<E4Base> StartState { get => startState; }

    public override State<E4Base> RemainState { get => remainState; }

    public override IEnumerable<Action<E4Base>> AlwaysUpdates { get => alwaysUpdates; }

    public override IEnumerable<Transition<E4Base>> TransitionsFromAnyState { get => transitionsFromAnyState; }

}
