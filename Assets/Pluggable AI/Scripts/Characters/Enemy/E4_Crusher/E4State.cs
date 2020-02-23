using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "E4State", menuName = "PluggableAI/State/Enemy/E4")]
public class E4State : State<E4Base>
{
    [SerializeField] E4Action[] startActions;
    [SerializeField] E4Action[] updateActions;
    [SerializeField] E4Action[] endActions;
    [SerializeField] E4Transition[] transitions;

    public override IEnumerable<Action<E4Base>> GetStartActions
    {
        get
        {
            return startActions;
        }
    }

    public override IEnumerable<Action<E4Base>> GetUpdateActions
    {
        get
        {
            return updateActions;
        }
    }

    public override IEnumerable<Action<E4Base>> GetEndActions
    {
        get
        {
            return endActions;
        }
    }

    public override IEnumerable<Transition<E4Base>> GetTransitions
    {
        get
        {
            return transitions;
        }
    }

}

