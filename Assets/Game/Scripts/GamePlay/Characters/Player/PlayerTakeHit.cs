using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeHit : CharacterTakeHit {
    private PlayerBase playerBase;
    public PlayerBase PlayerBase {
        get {
            if(playerBase == null) {
                playerBase = GetComponent<PlayerBase>();
            }
            return playerBase;
        }
    }
}

