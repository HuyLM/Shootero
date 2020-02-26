using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterTakeHit : MonoBehaviour
{
    private CharacterBase characterBase;
    protected CharacterBase CharacterBase {
        get {
            if(characterBase == null) {
                characterBase = GetComponent<CharacterBase>();
            }
            return characterBase;
        }
    }

    public virtual void Initalize() {

    }

    public void TakeHitDamage(HitInfor hit) {
        TakeHitDamage(hit.Damage.Value);
        foreach(var effect in hit.Effects) {
            effect.EffectTo(CharacterBase, hit.Causer, hit.Damage);
        }
    }

    public void TakeHitDamage(int damage) {
        CharacterBase.HealtherBase.HPReduce(damage);
    }

    public virtual void Countdown() {

    }
}
