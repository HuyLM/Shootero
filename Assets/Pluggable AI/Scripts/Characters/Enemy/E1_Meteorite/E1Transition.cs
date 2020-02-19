using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class E1Transition : Transition<E1Base>
{
    [SerializeField] protected E1Decision decision;
    [SerializeField] protected E1State trueState;
    [SerializeField] protected E1State falseState;
    [SerializeField] protected E1Action[] beforeTransitionActions;
    [SerializeField] protected E1Action[] whileTransitionActions;
    [SerializeField] protected E1Action[] afterTransitionActions;

    public override Decision<E1Base> Decision {
        get {
            return decision;
        }
    }

    public override State<E1Base> TrueState {
        get {
            return trueState;
        }
    }

    public override State<E1Base> FalseState {
        get {
            return falseState;
        }
    }

    public override IEnumerable<Action<E1Base>> BeforeTransitionActions => beforeTransitionActions;
    public override IEnumerable<Action<E1Base>> WhileTransitionActions => whileTransitionActions;
    public override IEnumerable<Action<E1Base>> AfterTransitionActions => afterTransitionActions;
}
