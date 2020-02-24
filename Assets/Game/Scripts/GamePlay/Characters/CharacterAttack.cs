﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAttack : MonoBehaviour {

    private CharacterBase characterBase;
    public CharacterBase CharacterBase
    {
        get
        {
            if(characterBase == null)
            {
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
