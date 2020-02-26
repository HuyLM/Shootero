
using System;
using System.Collections.Generic;

public abstract class Effect {
    protected string id;
    protected CharacterBase victim;
    protected CharacterBase causer;


    protected Effect(CharacterBase victim, CharacterBase causer) {
        this.victim = victim;
        this.causer = causer;
    }

    public abstract void EffectTo();
    protected abstract void RemoveFrom();

    public override bool Equals(object other) {
        if(other == null) return false;
        Effect effectOther = other as Effect;
        return this.id.Equals(effectOther.id) && victim == effectOther.victim && causer == effectOther.causer;
    }

    public override int GetHashCode() {
        return this.id.GetHashCode();
    }
}

public abstract class CountdownEffect : Effect {
    protected float effectDuration;
    protected Action onTimeOut;

    protected float effectCountdown;
    protected CountdownEffect(CharacterBase victim, CharacterBase causer, float duration) : base(victim, causer) {
        effectDuration = duration;
        effectCountdown = duration;
        onTimeOut += RemoveFrom;
    }

    public virtual void AddDupllicate(List<CountdownEffect> effects) {
        CountdownEffect effect = effects.Find(i => i.Equals(this));
        effect.Reset();
    }

    public virtual void AddTime(float time) {
        effectCountdown += time;
    }

    public virtual void Reset() {
        effectCountdown = effectDuration;
        UnityEngine.Debug.Log("Effect countdown reset" + id);
    }

    public void ListenOnComplete(Action onComplete) {
        onTimeOut += onComplete;
    }

    public virtual void Update(float deltaTime) {
        effectCountdown -= deltaTime;
        if (effectCountdown <= 0) {
            if (onTimeOut != null) {
                onTimeOut.Invoke();
            }
        }
    }


}
