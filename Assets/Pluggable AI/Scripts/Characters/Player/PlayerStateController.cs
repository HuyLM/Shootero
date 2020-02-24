using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : StateController<PlayerBase> {
    [SerializeField] protected PlayerState startState;
    [SerializeField] protected PlayerState remainState;
    [SerializeField] protected PlayerAction[] alwaysUpdates;
    [SerializeField] protected PlayerTransition[] transitionsFromAnyState;
    public override State<PlayerBase> StartState { get => startState; }

    public override State<PlayerBase> RemainState { get => remainState; }

    public override IEnumerable<Action<PlayerBase>> AlwaysUpdates { get => alwaysUpdates; }

    public override IEnumerable<Transition<PlayerBase>> TransitionsFromAnyState { get => transitionsFromAnyState; }

}
