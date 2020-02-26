using UnityEngine;


[CreateAssetMenu(fileName = "AttackSpeedUpModData", menuName = "ModData/Buff/AttackSpeedUp")]
public class AttackSpeedUpModData : BuffModData {
    [SerializeField] private StatModifier attackSpeedStat;
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        character.StaterPlayer.AtkSpeed.AddModifier(attackSpeedStat);
    }
}

