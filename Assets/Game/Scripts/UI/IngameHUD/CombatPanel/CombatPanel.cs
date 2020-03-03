using GameSystem.Common.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatPanel : Frame {
    [SerializeField] private ButtonBase btnPause;
    [SerializeField] private Image imgChip;
    [SerializeField] private TextMeshProUGUI txtChip;
    [SerializeField] private PlayerHealthBar playerHealthBar;
    [SerializeField] private TextMeshProUGUI txtCurrentWave;

    private void Start() {
        btnPause.onClick.AddListener(OnPauseButtonClicked);
        playerHealthBar.AddListenerHealthChanged(GameManager.Instance.GameLoader.Player);
        GameManager.Instance.GameLoader.Player.AddOnChipChanged(OnChipChanged);
    }

    private void OnEnable() {
        EventDispatcher.Instance.AddListener(EventKey.StartWave, OnWaveStart);

    }

    private void OnDisable() {
        EventDispatcher.Instance.RemoveListener(EventKey.StartWave, OnWaveStart);
    }


    private void OnPauseButtonClicked() {
        PopupHUD.Instance.Show<PausePopup>();
    }

    private void OnWaveStart() {
        txtCurrentWave.text = $"Wave {GameManager.Instance.CurrentWaveIndex + 1}";
    }

    private void OnChipChanged(int chip) {
        txtChip.text = chip.ToString();
    }

}
