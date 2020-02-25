using UnityEngine;


[CreateAssetMenu(fileName = "FocusModData", menuName = "ModData/ChangeBullet/FocusMod")]

public class FocusModData : ChangeBulletModData {
    public StatModifier bulletSizePercent;
    public StatModifier BDPercent;
    public override void ApplyTo(PlayerBase character) {
        character.AttackerPlayer.FocusUpgradeAttackComponent();
    }
}

public class FocusModInfor : ChangeBulletModInfor<FocusModData> {

    public override void ChangeBullet(BulletBase bullet) {
        bullet.Size.AddModifier(modData.bulletSizePercent);
        bullet.Damage.AddModifier(modData.BDPercent);
    }

}
