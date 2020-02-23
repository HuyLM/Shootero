using PluggableAI;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class E4Transition : Transition<E4Base>
{
    [SerializeField] protected E4Decision decision;
    [SerializeField] protected E4State trueState;
    [SerializeField] protected E4State falseState;
    [SerializeField] protected E4Action[] beforeTransitionActions;
    [SerializeField] protected E4Action[] whileTransitionActions;
    [SerializeField] protected E4Action[] afterTransitionActions;

    public override Decision<E4Base> Decision
    {
        get
        {
            return decision;
        }
    }

    public override State<E4Base> TrueState
    {
        get
        {
            return trueState;
        }
    }

    public override State<E4Base> FalseState
    {
        get
        {
            return falseState;
        }
    }

    public override IEnumerable<Action<E4Base>> BeforeTransitionActions => beforeTransitionActions;
    public override IEnumerable<Action<E4Base>> WhileTransitionActions => whileTransitionActions;
    public override IEnumerable<Action<E4Base>> AfterTransitionActions => afterTransitionActions;
}

