using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class E2Transition : Transition<E2Base>
{
    [SerializeField] protected E2Decision decision;
    [SerializeField] protected E2State trueState;
    [SerializeField] protected E2State falseState;
    [SerializeField] protected E2Action[] beforeTransitionActions;
    [SerializeField] protected E2Action[] whileTransitionActions;
    [SerializeField] protected E2Action[] afterTransitionActions;

    public override Decision<E2Base> Decision
    {
        get
        {
            return decision;
        }
    }

    public override State<E2Base> TrueState
    {
        get
        {
            return trueState;
        }
    }

    public override State<E2Base> FalseState
    {
        get
        {
            return falseState;
        }
    }

    public override IEnumerable<Action<E2Base>> BeforeTransitionActions => beforeTransitionActions;
    public override IEnumerable<Action<E2Base>> WhileTransitionActions => whileTransitionActions;
    public override IEnumerable<Action<E2Base>> AfterTransitionActions => afterTransitionActions;
}
