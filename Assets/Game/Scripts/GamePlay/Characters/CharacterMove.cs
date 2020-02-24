using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMove : MonoBehaviour
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

    [SerializeField] protected Rigidbody2D myRigi;

    public Rigidbody2D MyRigi {
        get {
            return myRigi;
        }
    }

    public virtual void Initalize() {

    }

    public virtual void Countdown() {

    }
}
