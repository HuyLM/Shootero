using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerTransition : Transition<PlayerBase> {
    [SerializeField] protected PlayerDecision decision;
    [SerializeField] protected PlayerState trueState;
    [SerializeField] protected PlayerState falseState;
    [SerializeField] protected PlayerAction[] beforeTransitionActions;
    [SerializeField] protected PlayerAction[] whileTransitionActions;
    [SerializeField] protected PlayerAction[] afterTransitionActions;

    public override Decision<PlayerBase> Decision {
        get {
            return decision;
        }
    }

    public override State<PlayerBase> TrueState {
        get {
            return trueState;
        }
    }

    public override State<PlayerBase> FalseState {
        get {
            return falseState;
        }
    }

    public override IEnumerable<Action<PlayerBase>> BeforeTransitionActions => beforeTransitionActions;
    public override IEnumerable<Action<PlayerBase>> WhileTransitionActions => whileTransitionActions;
    public override IEnumerable<Action<PlayerBase>> AfterTransitionActions => afterTransitionActions;
}