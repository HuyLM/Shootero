using PluggableAI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerState", menuName = "PluggableAI/State/Player")]
public class PlayerState : State<PlayerBase> {
    [SerializeField] PlayerAction[] startActions;
    [SerializeField] PlayerAction[] updateActions;
    [SerializeField] PlayerAction[] endActions;
    [SerializeField] PlayerTransition[] transitions;

    public override IEnumerable<Action<PlayerBase>> GetStartActions {
        get {
            return startActions;
        }
    }

    public override IEnumerable<Action<PlayerBase>> GetUpdateActions {
        get {
            return updateActions;
        }
    }

    public override IEnumerable<Action<PlayerBase>> GetEndActions {
        get {
            return endActions;
        }
    }

    public override IEnumerable<Transition<PlayerBase>> GetTransitions {
        get {
            return transitions;
        }
    }

}

