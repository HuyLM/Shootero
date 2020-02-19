using UnityEngine;
namespace PluggableAI {
    public abstract class Action<T> : ScriptableObject where T : CharacterBase{
        public abstract void Act(StateController<T> controller);
    }
}