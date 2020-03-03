using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ResultPopup : BasePopup {
    [SerializeField] private TextMeshProUGUI txtWave;
    [SerializeField] private TextMeshProUGUI txtZone;

    [SerializeField] private TextMeshProUGUI txtChip;

    protected override void OnShow(Action onCompleted = null, bool instant = false) {
        base.OnShow(onCompleted, instant);
        txtChip.text = GameManager.Instance.GameLoader.Player.ChipCollection.ToString();
    }

    public ResultPopup SetWave(int waveIndex) {
        txtWave.text = $"{waveIndex + 1}";
        return this;
    }

    public ResultPopup SetZone(int zoneIndex) {
        txtZone.text = $"Zone {zoneIndex + 1}";
        return this;
    }


}
