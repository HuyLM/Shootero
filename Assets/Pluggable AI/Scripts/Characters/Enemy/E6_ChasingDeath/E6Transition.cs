using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class E6Transition : Transition<E6Base> {
    [SerializeField] protected E6Decision decision;
    [SerializeField] protected E6State trueState;
    [SerializeField] protected E6State falseState;
    [SerializeField] protected E6Action[] beforeTransitionActions;
    [SerializeField] protected E6Action[] whileTransitionActions;
    [SerializeField] protected E6Action[] afterTransitionActions;

    public override Decision<E6Base> Decision {
        get {
            return decision;
        }
    }

    public override State<E6Base> TrueState {
        get {
            return trueState;
        }
    }

    public override State<E6Base> FalseState {
        get {
            return falseState;
        }
    }

    public override IEnumerable<Action<E6Base>> BeforeTransitionActions => beforeTransitionActions;
    public override IEnumerable<Action<E6Base>> WhileTransitionActions => whileTransitionActions;
    public override IEnumerable<Action<E6Base>> AfterTransitionActions => afterTransitionActions;
}