using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int currentHP;

    public int CurrentHp
    {
        get => currentHP;
    }

    public virtual void Countdown() {

    }
}
