
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
        return this.id.Equals((other as Effect).id) ;
    }

    public override int GetHashCode() {
        return this.id.GetHashCode();
    }
}

public abstract class CountdownEffect : Effect {
    protected float effectDuration;
    protected Action onTimeOut;

    protected float effectTimer;
    protected CountdownEffect(CharacterBase victim, CharacterBase causer, float duration) : base(victim, causer) {
        effectDuration = duration;
        effectTimer = duration;
        onTimeOut += RemoveFrom;
    }

    public virtual void AddDupllicate(List<CountdownEffect> effects) {
        CountdownEffect effect = effects.Find(i => i.Equals(this));
        effect.Reset();
    }

    public virtual void AddTime(float time) {
        effectTimer += time;
    }

    public virtual void Reset() {
        effectTimer = effectDuration;
        UnityEngine.Debug.Log("Effect countdown reset" + id);
    }

    public void ListenOnComplete(Action onComplete) {
        onTimeOut += onComplete;
    }

    public virtual void Update(float deltaTime) {
        effectTimer -= deltaTime;
        if (effectTimer <= 0) {
            if (onTimeOut != null) {
                onTimeOut.Invoke();
            }
        }
    }


}
