using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModItemDisplayer : MonoBehaviour
{
    [SerializeField] private Image imgIcon;
    [SerializeField] private TextMeshProUGUI txtName;
    [SerializeField] private ButtonBase btnChoose;

    private ModData modData;

    private void Start()
    {
        btnChoose.onClick.AddListener(OnChooseButtonClicked);
    }
    public void SetModData(ModData mod)
    {
        modData = mod;
        SetIcon(mod.icon);
        SetName(mod.nameMod);
    }
    public ModItemDisplayer SetIcon(Sprite sprite)
    {
        imgIcon.sprite = sprite;
        return this;
    }

    public ModItemDisplayer SetName(string name)
    {
        txtName.text = name;
        return this;
    }

    private void OnChooseButtonClicked()
    {
        modData.ApplyTo(GameManager.Instance.GameLoader.Player);
        GameManager.Instance.GameLoader.Player.LevelerPlayer.CurrentUpgradeLevel++;
        PopupHUD.Instance.Hide<LevelupPopup>();
    }
}
