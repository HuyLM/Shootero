using System.Collections;
using UnityEngine;

public class PlayerPiercingGunComponent : PlayerAttackComponent {
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;
    [SerializeField] private float halfDistanceBase = 0.5f;
    [SerializeField] private float distanceUpgradeX = 0.2f;
    [SerializeField] private float distanceUpgradeY = 0.03f;
    [SerializeField] private float reduceDB = 0.1f;

    private int numberBullet;

    public override void FocusUpgrade() {
        halfDistanceBase *= 2.0f / 3;
    }

    public override void Initalize() {
        base.Initalize();
        numberBullet = 2;
    }

    [ContextMenu("upgrade")]
    public override void Upgrade() {
        base.Upgrade();
        numberBullet += 2;
        Debug.Log("reduce: " + reduceDB);
    }

    protected override void Attacking() {
        Vector2 directionShot = Vector2.up;
        for (int ibullet = 0; ibullet < numberBullet / 2; ++ibullet) {
            FrontBullet goLeft = Instantiate(bullet, (Vector2)firePoint.position + Vector2.left * (halfDistanceBase + ibullet * distanceUpgradeX) + Vector2.down * (ibullet * distanceUpgradeY), Quaternion.identity);
            goLeft.Shoot(speedBullet, directionShot);

            FrontBullet goRight = Instantiate(bullet, (Vector2)firePoint.position + Vector2.right * (halfDistanceBase + ibullet * distanceUpgradeX) + Vector2.down * (ibullet * distanceUpgradeY), Quaternion.identity);
            goRight.Shoot(speedBullet, directionShot);
        }
        EndAttacking();
    }
}
