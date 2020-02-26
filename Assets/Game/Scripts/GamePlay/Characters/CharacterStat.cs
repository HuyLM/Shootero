using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStat : MonoBehaviour {
    [SerializeField] private IntStat maxHP;
    [SerializeField] private IntStat atk;

    private CharacterBase characterBase;
    public CharacterBase CharacterBase {
        get {
            if (characterBase == null) {
                characterBase = GetComponent<CharacterBase>();
            }
            return characterBase;
        }
    }

    public IntStat Atk { get => atk;}
    public IntStat MaxHP { get => maxHP; }

    public virtual void Initalize() {

    }

    public virtual void Countdown() {

    }
}
