using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class E5Transition : Transition<E5Base> {
    [SerializeField] protected E5Decision decision;
    [SerializeField] protected E5State trueState;
    [SerializeField] protected E5State falseState;
    [SerializeField] protected E5Action[] beforeTransitionActions;
    [SerializeField] protected E5Action[] whileTransitionActions;
    [SerializeField] protected E5Action[] afterTransitionActions;

    public override Decision<E5Base> Decision {
        get {
            return decision;
        }
    }

    public override State<E5Base> TrueState {
        get {
            return trueState;
        }
    }

    public override State<E5Base> FalseState {
        get {
            return falseState;
        }
    }

    public override IEnumerable<Action<E5Base>> BeforeTransitionActions => beforeTransitionActions;
    public override IEnumerable<Action<E5Base>> WhileTransitionActions => whileTransitionActions;
    public override IEnumerable<Action<E5Base>> AfterTransitionActions => afterTransitionActions;
}