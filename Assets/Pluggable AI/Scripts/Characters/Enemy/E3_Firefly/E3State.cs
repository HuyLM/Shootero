using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "E3State", menuName = "PluggableAI/State/Enemy/E3")]
public class E3State : State<E3Base> {
    [SerializeField] E3Action[] startActions;
    [SerializeField] E3Action[] updateActions;
    [SerializeField] E3Action[] endActions;
    [SerializeField] E3Transition[] transitions;

    public override IEnumerable<Action<E3Base>> GetStartActions {
        get {
            return startActions;
        }
    }

    public override IEnumerable<Action<E3Base>> GetUpdateActions {
        get {
            return updateActions;
        }
    }

    public override IEnumerable<Action<E3Base>> GetEndActions {
        get {
            return endActions;
        }
    }

    public override IEnumerable<Transition<E3Base>> GetTransitions {
        get {
            return transitions;
        }
    }

}

