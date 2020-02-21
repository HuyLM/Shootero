using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "E6State", menuName = "PluggableAI/State/Enemy/E6")]
public class E6State : State<E6Base> {
    [SerializeField] E6Action[] startActions;
    [SerializeField] E6Action[] updateActions;
    [SerializeField] E6Action[] endActions;
    [SerializeField] E6Transition[] transitions;

    public override IEnumerable<Action<E6Base>> GetStartActions {
        get {
            return startActions;
        }
    }

    public override IEnumerable<Action<E6Base>> GetUpdateActions {
        get {
            return updateActions;
        }
    }

    public override IEnumerable<Action<E6Base>> GetEndActions {
        get {
            return endActions;
        }
    }

    public override IEnumerable<Transition<E6Base>> GetTransitions {
        get {
            return transitions;
        }
    }

}

