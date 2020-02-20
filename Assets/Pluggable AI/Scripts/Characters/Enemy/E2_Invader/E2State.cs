using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "E2State", menuName = "PluggableAI/State/Enemy/E2")]
public class E2State : State<E2Base>
{
    [SerializeField] E2Action[] startActions;
    [SerializeField] E2Action[] updateActions;
    [SerializeField] E2Action[] endActions;
    [SerializeField] E2Transition[] transitions;

    public override IEnumerable<Action<E2Base>> GetStartActions
    {
        get
        {
            return startActions;
        }
    }

    public override IEnumerable<Action<E2Base>> GetUpdateActions
    {
        get
        {
            return updateActions;
        }
    }

    public override IEnumerable<Action<E2Base>> GetEndActions
    {
        get
        {
            return endActions;
        }
    }

    public override IEnumerable<Transition<E2Base>> GetTransitions
    {
        get
        {
            return transitions;
        }
    }

}

