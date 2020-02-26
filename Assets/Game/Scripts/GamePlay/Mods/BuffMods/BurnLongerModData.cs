using UnityEngine;


[CreateAssetMenu(fileName = "BurnLongerModData", menuName = "ModData/Buff/BurnLonger")]
public class BurnLongerModData : BuffModData {
    [SerializeField] private BurnShotModData burnMod;
    [SerializeField] private StatModifier burnDuration;
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        BurnShotModInfor burnInfor = character.SkillerPlayer.GetModInfor<BurnShotModInfor>(burnMod.modId);
        burnInfor.Duration.AddModifier(burnDuration);
    }
}

