using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace PluggableAI {
    [CreateAssetMenu(menuName = "PluggableAI/State")]
    public abstract class State<T> : ScriptableObject where T : CharacterBase{
        [SerializeField] private string nameState;
        public abstract IEnumerable<Action<T>> GetStartActions { get; }
        public abstract IEnumerable<Action<T>> GetUpdateActions { get; }
        public abstract IEnumerable<Action<T>> GetEndActions { get; }
        public abstract IEnumerable<Transition<T>> GetTransitions { get; }
        [SerializeField] protected Color sceneGizmoColor = Color.grey;
        public Color SceneGizmoColor { get => sceneGizmoColor; private set { } }
        public string NameState { get => nameState; }
        
        public void StartState(StateController<T> controller) {
            DoStartActions(controller);
        }

        public void UpdateState(StateController<T> controller) {
            DoUpdateActions(controller);
            CheckTransitions(controller);
        }

        public void EndState(StateController<T> controller) {
            DoEndActions(controller);
        }

        protected virtual void DoStartActions(StateController<T> controller) {
            GetStartActions.DoAllAction(controller);
        }

        protected virtual void DoUpdateActions(StateController<T> controller) {
            GetUpdateActions.DoAllAction(controller);
        }

        protected virtual void DoEndActions(StateController<T> controller) {
            GetEndActions.DoAllAction(controller);
        }

        protected virtual void CheckTransitions(StateController<T> controller) {
            foreach(Transition<T> transition in GetTransitions) {
                bool decisionSucceeded = transition.Decision.DecideWitElapssed(controller);
                if(decisionSucceeded) {
                    controller.TransitionToState(transition.TrueState, transition);
                }
                else {
                    controller.TransitionToState(transition.FalseState, transition);
                }
            }
        }

    }
}