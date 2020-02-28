using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour {
    private PlayerBase playerBase;
    public PlayerBase PlayerBase {
        get {
            if(playerBase == null) {
                playerBase = GetComponent<PlayerBase>();
            }
            return playerBase;
        }
    }
    [SerializeField] private int currentLevel;
    [SerializeField] private int currentEXP;

    private Action<int> onExpChanged;
    private Action<int> onLevelChanged;


    public int CurrentLevel { get => currentLevel; }
    public int CurrentEXP { get => currentEXP; }

    public int ExpNeedNextLevel() {
        int currentWave = 0;
        return (int)(50 * (0.8f + 0.2f * currentWave) * currentLevel);
    }

    public void AddExp(int exp) {
        int curExp = currentEXP;
        curExp += exp;
        int expNeedNextLevel = ExpNeedNextLevel();
        if(curExp >= expNeedNextLevel) {
            LevelUp();
            curExp -= expNeedNextLevel;
        }
        currentEXP = curExp;
        onExpChanged?.Invoke(currentEXP);
    }

    protected void LevelUp() {
        currentLevel++;
        onLevelChanged?.Invoke(currentLevel);
    }

    public void AddOnExpChanged(Action<int> onExpChanged) {
        this.onExpChanged += onExpChanged;
    }

    public void RemoveOnExpChanged(Action<int> onExpChanged) {
        this.onExpChanged -= onExpChanged;
    }

    public void AddOnLevelChanged(Action<int> onLevelChanged) {
        this.onLevelChanged += onLevelChanged;
    }

    public void RemoveOnLevelChanged(Action<int> onLevelChanged) {
        this.onLevelChanged -= onLevelChanged;
    }
}
