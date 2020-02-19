using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterMove : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D myRigi;

    public Rigidbody2D MyRigi {
        get {
            return myRigi;
        }
    }

    public virtual void Countdown() {

    }
}
