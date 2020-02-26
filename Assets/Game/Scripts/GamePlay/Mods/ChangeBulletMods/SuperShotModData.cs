using UnityEngine;


[CreateAssetMenu(fileName = "SuperShotModData", menuName = "ModData/ChangeBullet/SuperShot")]

public class SuperShotModData : ChangeBulletModData {
    public StatModifier bulletSizePercent;
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        character.SkillerPlayer.AddChangeBulletMod(new SuperShotModInfor(this));
    }
}

public class SuperShotModInfor : ChangeBulletModInfor<SuperShotModData> {
    public SuperShotModInfor(SuperShotModData mod) : base(mod) {

    }

    public SuperShotModInfor(SuperShotModInfor mod) : base(mod) {

    }

    public override void ChangeBullet(BulletBase bullet) {
        bullet.Size.AddModifier(modData.bulletSizePercent);
        bullet.ChangeSize();
    }

    public override object Clone() {
        return new SuperShotModInfor(this);
    }
}

