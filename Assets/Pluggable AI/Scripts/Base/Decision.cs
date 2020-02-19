using UnityEngine;
namespace PluggableAI {
    public abstract class Decision<T> : ScriptableObject where T : CharacterBase {
        [SerializeField] protected bool useElapsedTime;
        [SerializeField] protected float elapsedTime;
        public float ElapsedTime { get => elapsedTime; }

        public bool DecideWitElapssed(StateController<T> controller) {
            if (useElapsedTime && !controller.CheckIfCountDownElapsed(elapsedTime)) {
                return false;
            }
            return Decide(controller);
        }
        protected abstract bool Decide(StateController<T> controller);
    }
}