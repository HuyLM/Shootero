using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.Common.UI;
using System;

public class LevelupPopup : DOTweenFrame
{
    [SerializeField] private ModItemDisplayer[] displayers;

    protected override void OnShow(Action onCompleted = null, bool instant = false)
    {
        base.OnShow(onCompleted, instant);
        bool isAttackMod = GameManager.Instance.GameLoader.Player.LevelerPlayer.CurrentUpgradeLevel == 0;
        SetDisplayer(GameResource.Instance.ModGenerator.GetRandomModDatas(isAttackMod));
    }
    public void SetDisplayer(ModData[] mods)
    {
        for(int i = 0; i < mods.Length; ++i)
        {
            displayers[i].SetModData(mods[i]);
        }
    }
}
