using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ModItemDisplayer : MonoBehaviour {
    [SerializeField] private Image imgIcon;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private ButtonBase btnChoose;

    private Action onItemClicked;

    private void Start() {
        btnChoose.onClick.AddListener(OnChooseButtonClicked);
    }
    public ModItemDisplayer SetIcon(Sprite sprite) {
        imgIcon.sprite = sprite;
        return this;
    }

    public ModItemDisplayer SetName(string name) {
        txtName.text = name;
        return this;
    }

    public ModItemDisplayer OnItemClicked(Action onClick) {
        onItemClicked = onClick;
        return this;
    }

    private void OnChooseButtonClicked() {
        onItemClicked?.Invoke();
    }
}
