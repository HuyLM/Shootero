using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "E1State", menuName = "PluggableAI/State/Enemy/E1")]
public class E1State : State<E1Base>
{
    [SerializeField] E1Action[] startActions;
    [SerializeField] E1Action[] updateActions;
    [SerializeField] E1Action[] endActions;
    [SerializeField] E1Transition[] transitions;

    public override IEnumerable<Action<E1Base>> GetStartActions {
        get {
            return startActions;
        }
    }

    public override IEnumerable<Action<E1Base>> GetUpdateActions {
        get {
            return updateActions;
        }
    }

    public override IEnumerable<Action<E1Base>> GetEndActions {
        get {
            return endActions;
        }
    }

    public override IEnumerable<Transition<E1Base>> GetTransitions {
        get {
            return transitions;
        }
    }

}
