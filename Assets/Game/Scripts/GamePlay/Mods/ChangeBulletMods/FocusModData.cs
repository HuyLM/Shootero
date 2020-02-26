using UnityEngine;


[CreateAssetMenu(fileName = "FocusModData", menuName = "ModData/ChangeBullet/FocusMod")]

public class FocusModData : ChangeBulletModData {
    public StatModifier bulletSizePercent;
    public StatModifier BDPercent;
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        character.AttackerPlayer.FocusUpgradeAttackComponent();
        character.SkillerPlayer.AddChangeBulletMod(new FocusModInfor(this));
    }
}

public class FocusModInfor : ChangeBulletModInfor<FocusModData> {
    public FocusModInfor(FocusModData mod) : base(mod) {

    }

    public FocusModInfor(FocusModInfor mod) : base(mod) {

    }

    public override void ChangeBullet(BulletBase bullet) {
        bullet.Size.AddModifier(modData.bulletSizePercent);
        bullet.ChangeSize();
        bullet.HitInfor.Damage.AddModifier(modData.BDPercent);
    }

    public override object Clone() {
        return new FocusModInfor(this);
    }
}
