using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class E3Transition : Transition<E3Base> {
    [SerializeField] protected E3Decision decision;
    [SerializeField] protected E3State trueState;
    [SerializeField] protected E3State falseState;
    [SerializeField] protected E3Action[] beforeTransitionActions;
    [SerializeField] protected E3Action[] whileTransitionActions;
    [SerializeField] protected E3Action[] afterTransitionActions;

    public override Decision<E3Base> Decision {
        get {
            return decision;
        }
    }

    public override State<E3Base> TrueState {
        get {
            return trueState;
        }
    }

    public override State<E3Base> FalseState {
        get {
            return falseState;
        }
    }

    public override IEnumerable<Action<E3Base>> BeforeTransitionActions => beforeTransitionActions;
    public override IEnumerable<Action<E3Base>> WhileTransitionActions => whileTransitionActions;
    public override IEnumerable<Action<E3Base>> AfterTransitionActions => afterTransitionActions;
}

