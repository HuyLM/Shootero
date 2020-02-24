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

    public void TakeHitDamege(int damage) {
        CharacterBase.HealtherBase.HPReduce(damage);
    }

    public virtual void Countdown() {

    }
}
