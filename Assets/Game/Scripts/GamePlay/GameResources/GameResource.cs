﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "GameResource", fileName = "GameResource")]
public class GameResource : ScriptableObject {

    #region Singleton
    private static GameResource instance;
    public static GameResource Instance {
        get {
            if(instance == null) {
                instance = Resources.Load<GameResource>("GameResource");
            }
            return instance;
        }
    }

    #endregion

    [SerializeField] private ConquerorData conquerorData;
    public ConquerorData ConquerorData { get => conquerorData; }


}
