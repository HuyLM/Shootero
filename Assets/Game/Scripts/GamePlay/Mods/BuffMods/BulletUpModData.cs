using UnityEngine;


[CreateAssetMenu(fileName = "BulletUpModData", menuName = "ModData/Buff/BulletUp")]
public class BulletUpModData : BuffModData {
    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        character.AttackerPlayer.UpgradeAttackComponent();
    }
}
