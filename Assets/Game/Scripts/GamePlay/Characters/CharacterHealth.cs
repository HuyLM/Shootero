using System;
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

    [SerializeField] protected int currentHP;

    protected Action<int> onHpChanged;

    public virtual int CurrentHp
    {
        get {
            return currentHP;
        }
        protected set {
            currentHP = value;
            onHpChanged?.Invoke(currentHP);
        }
    }

    public void AddOnHpChanged(Action<int> onHpChanged) {
        this.onHpChanged += onHpChanged;
    }

    public void RemoveOnHpChanged(Action<int> onHpChanged) {
        this.onHpChanged -= onHpChanged;
    }

    public void HPReduce(int hp) {
        CurrentHp -= hp;
    }

    public void AddHp(int hp) {
        CurrentHp += hp;
    }

    public void ForceChangeCurrentHp(int hp) {
        CurrentHp = hp;
    }

    public virtual void Initalize() {

    }

    public virtual void Countdown() {

    }
}
