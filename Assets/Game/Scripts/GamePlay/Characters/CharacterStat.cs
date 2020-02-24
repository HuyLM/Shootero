using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStat : MonoBehaviour {
    [SerializeField] private int maxHP;
    [SerializeField] private int atk;

    private CharacterBase characterBase;
    public CharacterBase CharacterBase {
        get {
            if (characterBase == null) {
                characterBase = GetComponent<CharacterBase>();
            }
            return characterBase;
        }
    }

    public virtual void Initalize() {

    }

    public virtual void Countdown() {

    }
}
