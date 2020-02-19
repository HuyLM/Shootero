using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterHealth : MonoBehaviour
{
    [SerializeField] private int currentHP;

    public virtual void Countdown() {

    }
}
