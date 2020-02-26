using UnityEngine;


[CreateAssetMenu(fileName = "BurnStrengthModData", menuName = "ModData/Buff/BurnStrength")]
public class BurnStrengthModData : BuffModData {
    [SerializeField] private BurnShotModData burnMod;
    [SerializeField] private StatModifier burnDmg;
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        BurnShotModInfor burnInfor = character.SkillerPlayer.GetModInfor<BurnShotModInfor>(burnMod.modId);
        burnInfor.DamagePercent.AddModifier(burnDmg);
    }
}

