using System.Collections.Generic;
using UnityEngine;

namespace PluggableAI {
    public abstract class StateController<T> : MonoBehaviour  where T : CharacterBase {
        private T character;
        public abstract State<T> StartState { get; }
        public abstract State<T> RemainState { get; }
        public abstract IEnumerable<Action<T>> AlwaysUpdates { get; }
        public abstract IEnumerable<Transition<T>> TransitionsFromAnyState { get; } 
        private float stateTimeElapsed;
        private State<T> currentState;

        public T Character {
            get {
                if(character == null) {
                    character = GetComponent<T>();
                    if(character == null) {
                        PluggableAIHelper.LogError("Character is NULL", this.name);
                    }
                }
                return character;
            }
        }

        public void SetCurrentState(State<T> currentState) {
            this.currentState = currentState;
        }

        void Awake() {
            character = GetComponent<T>();
        }

        private void Start() {
            SetCurrentState(StartState);
            StartState.StartState(this);
        }

        void Update() {
            AlwaysUpdates.DoAllAction<T>(this);
            // any state to state
            foreach(var transition in TransitionsFromAnyState) {
                bool decisionSucceeded = transition.Decision.DecideWitElapssed(this);
                if(decisionSucceeded) {
                    TransitionToState(transition.TrueState, transition);
                    break;
                }
            }
            currentState.UpdateState(this);
            stateTimeElapsed += Time.deltaTime;
        }

        public void TransitionToState(State<T> nextState, Transition<T> transition) {
            if(nextState != RemainState && currentState != nextState) {
                PluggableAIHelper.Log(string.Format("Transition: {0} to {1} by {2}", currentState.NameState.AddColorToString(currentState.SceneGizmoColor), nextState.NameState.AddColorToString(nextState.SceneGizmoColor), transition.NameTransition));
                transition.DoBeforeTransitionActions(this);
                currentState.EndState(this);
                transition.DoWhileTransitionActions(this);
                SetCurrentState(nextState);
                transition.DoAfterTransitionActions(this);
                nextState.StartState(this);
                OnExitState();
            }
        }

        public bool CheckIfCountDownElapsed(float duration) {
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState() {
            stateTimeElapsed = 0;
        }

        void OnDrawGizmos() {
            if(currentState != null) {
                Gizmos.color = currentState.SceneGizmoColor;
                Gizmos.DrawWireSphere(transform.position, 0.5f);
            }
        }
    }
}
