using TMPro;
using UnityEngine;

public class PlayerHealthBar : ProgressBarBase {
    [SerializeField] private TextMeshProUGUI txtPlayerHealth;


    public void AddListenerHealthChanged(PlayerBase player) {
        player.HealtherPlayer.AddOnHpChanged(HandlePlayerHealthChanged);
    }

    public void RemoveListenerHealthChanged(PlayerBase player) {
        player.HealtherPlayer.RemoveOnHpChanged(HandlePlayerHealthChanged);
    }

    private void HandlePlayerHealthChanged(int health, float pct) {
        txtPlayerHealth.text = health.ToString();
        HandleBarChanged(pct);
    }
}
