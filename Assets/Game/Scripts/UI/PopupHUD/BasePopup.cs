﻿using GameSystem.Common.UI;
using System;
using TMPro;
using UnityEngine;

public class BasePopup : DOTweenFrame {

    [Header("[References]")]
    [SerializeField] private TextMeshProUGUI tileText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private ButtonBase closeTap;
    [SerializeField] private ButtonBase closeButton;
    [SerializeField] private TextMeshProUGUI closeText;

    private Action closeAction;
    private Action preCloseAction;

    protected string nameFrame;

    protected virtual void Start() {
        if(closeButton) {
            closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        if(closeTap) {
            closeTap.onClick.AddListener(OnCloseButtonClicked);
        }
    }

    protected override void OnShow(Action onCompleted = null, bool instant = false) {
        base.OnShow(onCompleted, instant);
        SetTapState(true);
        SetTittle(null, false);
        SetMessage(null, false);
        SetCloseContent(null, false);
        OnClose(null);
        SetCloseState(true, true);

        OnPreClose(() => {
            //// [Tracking - Position]-[ButtonBack]
            //GameTracking.TrackingButtonPress("btn_back", this);
        });

        OnClose(() => {
            //// [Tracking - Position]-[menuShowUp]
            //Frame topFrame = GameInfor.Instance.GetOnTopFrame();
            //topFrame.SetPreviousNameFrame(this.GetCurrentNameFrame());
            //GameTracking.TrackingMenuShow(topFrame);
        });
    }

    public BasePopup SetTittle(string tile, bool show = true) {
        if(this.tileText) {
            this.tileText.gameObject.SetActive(show);
            if(show) {
                this.tileText.text = tile;
            }
        }
        return this;
    }

    public BasePopup SetMessage(string message, bool show = true) {
        if(this.messageText) {
            this.messageText.gameObject.SetActive(show);
            if(show) {
                this.messageText.text = message;
            }
        }
        return this;
    }

    public BasePopup SetCloseContent(string content, bool show = true) {
        if(this.closeText) {
            this.closeText?.gameObject.SetActive(show);
            if(show) {
                this.closeText.text = content;
            }
        }
        return this;
    }

    public BasePopup OnClose(Action closeAction) {
        this.closeAction = closeAction;
        return this;
    }

    public BasePopup OnPreClose(Action preCloseAction) {
        this.preCloseAction = preCloseAction;
        return this;
    }

    public BasePopup SetCloseState(bool interactable, bool show = true) {
        if(closeButton) {
            closeButton.gameObject.SetActive(show);
            if(show) {
                closeButton.SetState(interactable);
            }
        }
        return this;
    }

    protected virtual void OnCloseButtonClicked() {
        SetTapState(false);
        preCloseAction?.Invoke();
        Hide();
        closeAction?.Invoke();
    }

    public override Frame OnBack() {
        OnBackButtonClicked();
        return this;
    }

    protected virtual void OnBackButtonClicked() {
        OnCloseButtonClicked();
    }

    public BasePopup SetTapState(bool interactable, bool show = true) {
        if(closeTap) {
            closeTap.gameObject.SetActive(show);
            if(show) {
                closeTap.SetState(interactable);
            }
        }
        return this;
    }

    public BasePopup SetCurrentNameFrame(string name) {
        nameFrame = name;
        return this;
    }

}
