using UnityEngine;


[CreateAssetMenu(fileName = "AttackUpModData", menuName = "ModData/Buff/AttackUp")]
public class AttackUpModData : BuffModData {
    [SerializeField] private StatModifier attackStat;
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        character.StaterPlayer.Atk.AddModifier(attackStat);
    }
}
