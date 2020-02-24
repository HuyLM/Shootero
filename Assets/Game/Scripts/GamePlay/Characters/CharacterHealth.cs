using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterHealth : MonoBehaviour
{
    private CharacterBase characterBase;
    public CharacterBase CharacterBase {
        get {
            if (characterBase == null) {
                characterBase = GetComponent<CharacterBase>();
            }
            return characterBase;
        }
    }

    [SerializeField] private int currentHP;

    public int CurrentHp
    {
        get => currentHP;
    }

    public void HPReduce(int hp) {
        currentHP -= hp;
    }

    public virtual void Initalize() {

    }

    public virtual void Countdown() {

    }
}
