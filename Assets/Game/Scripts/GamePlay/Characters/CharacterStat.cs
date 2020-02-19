using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStat : MonoBehaviour {
    [SerializeField] private int maxHP;
    [SerializeField] private int atk;

    public virtual void Countdown() {

    }
}
