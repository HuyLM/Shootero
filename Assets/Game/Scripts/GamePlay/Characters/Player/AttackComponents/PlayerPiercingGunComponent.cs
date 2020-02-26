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
    private float currentReduceDB = 0f;

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
        currentReduceDB += reduceDB;
    }

    protected override T ChangeBullet<T>(T bullet) {
        T bulletChanged = base.ChangeBullet(bullet);
        bulletChanged.HitInfor.Damage.AddModifier(new StatModifier(currentReduceDB, StatModType.PercentAdd));
        return bulletChanged;
    }

    protected override void Attacking() {
        FrontBullet bulletChanged = ChangeBullet<FrontBullet>(bullet);
        Vector2 directionShot = Vector2.up;
        for (int ibullet = 0; ibullet < numberBullet / 2; ++ibullet) {
            FrontBullet goLeft = Instantiate(bulletChanged, (Vector2)firePoint.position + Vector2.left * (halfDistanceBase + ibullet * distanceUpgradeX) + Vector2.down * (ibullet * distanceUpgradeY), Quaternion.identity);
            goLeft.SetHitInfor(bulletChanged);
            goLeft.Shoot(speedBullet, directionShot);

            FrontBullet goRight = Instantiate(bulletChanged, (Vector2)firePoint.position + Vector2.right * (halfDistanceBase + ibullet * distanceUpgradeX) + Vector2.down * (ibullet * distanceUpgradeY), Quaternion.identity);
            goRight.SetHitInfor(bulletChanged);
            goRight.Shoot(speedBullet, directionShot);
        }

        PoolManager.Recycle(bulletChanged);
        EndAttacking();
    }
}
