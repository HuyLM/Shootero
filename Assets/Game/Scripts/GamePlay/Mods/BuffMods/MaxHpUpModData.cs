using UnityEngine;


[CreateAssetMenu(fileName = "MaxHpUpModData", menuName = "ModData/Buff/MaxHpUp")]
public class MaxHpUpModData : BuffModData {
    [SerializeField] private StatModifier maxHp;
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        int oldMaxHp = character.StaterPlayer.MaxHP.Value;
        character.StaterPlayer.MaxHP.AddModifier(maxHp);
        int newMaxHp = character.StaterPlayer.MaxHP.Value;
        character.HealtherPlayer.AddHp(newMaxHp - oldMaxHp);
    }
}

