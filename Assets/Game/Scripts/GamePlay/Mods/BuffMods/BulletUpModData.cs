using UnityEngine;


[CreateAssetMenu(fileName = "BulletUpModData", menuName = "ModData/Buff/BulletUp")]
public class BulletUpModData : BuffModData {
    public override void ApplyTo(PlayerBase character) {
        character.AttackerPlayer.UpgradeAttackComponent();
    }
}
