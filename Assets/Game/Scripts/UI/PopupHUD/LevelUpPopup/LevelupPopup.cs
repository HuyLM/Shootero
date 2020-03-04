using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.Common.UI;
using System;

public class LevelupPopup : DOTweenFrame {
    [SerializeField] private ModItemDisplayer[] displayers;

    protected override void OnShow(Action onCompleted = null, bool instant = false) {
        base.OnShow(onCompleted, instant);
        GameManager.Instance.Pause();
        GeneralMods();
    }

    protected override void OnHide(Action onCompleted = null, bool instant = false) {
        base.OnHide(onCompleted, instant);
        GameManager.Instance.Resume();
    }
    private void SetDisplayer(ModData[] mods) {
        for(int i = 0; i < mods.Length; ++i) {
            int index = i;
            displayers[i].SetIcon(mods[i].icon).SetName(mods[i].nameMod);
            displayers[i].OnItemClicked(() => {
                mods[index].ApplyTo(GameManager.Instance.GameLoader.Player);
                GameManager.Instance.GameLoader.Player.LevelerPlayer.CurrentUpgradeLevel++;
                if(GameManager.Instance.GameLoader.Player.LevelerPlayer.HasUpgradePoint) {
                    GeneralMods();
                }
                else {
                    this.Hide();
                }
            });
        }
    }

    public void GeneralMods() {
        bool isAttackMod = GameManager.Instance.GameLoader.Player.LevelerPlayer.CurrentUpgradeLevel == 0;
        SetDisplayer(GameResource.Instance.ModGenerator.GetRandomModDatas(isAttackMod));
    }
}
