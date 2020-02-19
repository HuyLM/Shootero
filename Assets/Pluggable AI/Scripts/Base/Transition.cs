
using System.Collections.Generic;
using UnityEngine;


namespace PluggableAI {
    [System.Serializable]
    public abstract class Transition<T> where T : CharacterBase {
        [SerializeField] private string nameTransition;
        public abstract Decision<T> Decision { get; }
        public abstract State<T> TrueState { get; }
        public abstract State<T> FalseState { get; }
        public abstract IEnumerable<Action<T>> BeforeTransitionActions { get; }
        public abstract IEnumerable<Action<T>> WhileTransitionActions { get; }
        public abstract IEnumerable<Action<T>> AfterTransitionActions { get; }
        public string NameTransition { get => nameTransition; }

        public virtual void DoBeforeTransitionActions(StateController<T> controller) {
            BeforeTransitionActions.DoAllAction(controller);
        }

        public virtual void DoWhileTransitionActions(StateController<T> controller) {
            WhileTransitionActions.DoAllAction(controller);
        }

        public virtual void DoAfterTransitionActions(StateController<T> controller) {
            AfterTransitionActions.DoAllAction(controller);
        }
    }
}