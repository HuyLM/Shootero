using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSystem.Common.UI;
using System;

public class PausePopup : DOTweenFrame {
    [SerializeField] private ButtonBase btnResume;
    [SerializeField] private ButtonBase btnHome;
    [SerializeField] private ButtonBase btnSound;

    private void Start() {
        btnResume.onClick.AddListener(OnResumeButtonClicked);
    }

    protected override void OnShow(Action onCompleted = null, bool instant = false) {
        base.OnShow(onCompleted, instant);
        GameManager.Instance.Pause();
    }

    protected override void OnHide(Action onCompleted = null, bool instant = false) {
        base.OnHide(onCompleted, instant);
        GameManager.Instance.Resume();
    }


    private void OnResumeButtonClicked() {
        OnBack();
    }

    private void OnHomeButtonClicked() {

    }
    private void OnSoundButtonClicked() {

    }
}
