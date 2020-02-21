using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "E5State", menuName = "PluggableAI/State/Enemy/E5")]
public class E5State : State<E5Base> {
    [SerializeField] E5Action[] startActions;
    [SerializeField] E5Action[] updateActions;
    [SerializeField] E5Action[] endActions;
    [SerializeField] E5Transition[] transitions;

    public override IEnumerable<Action<E5Base>> GetStartActions {
        get {
            return startActions;
        }
    }

    public override IEnumerable<Action<E5Base>> GetUpdateActions {
        get {
            return updateActions;
        }
    }

    public override IEnumerable<Action<E5Base>> GetEndActions {
        get {
            return endActions;
        }
    }

    public override IEnumerable<Transition<E5Base>> GetTransitions {
        get {
            return transitions;
        }
    }

}

