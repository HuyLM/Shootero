using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplitterComponent : PlayerAttackComponent {
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;
    [SerializeField] private float spreadAngle;
    [SerializeField] private float reduceDB = -0.1f;

    private int numberBullet;
    private float currentReduceDB = 0f;

    public override void FocusUpgrade() {
        spreadAngle = 3;
    }

    public override void Initalize() {
        base.Initalize();
        numberBullet = 3;
    }

    [ContextMenu("upgrade")]
    public override void Upgrade() {
        base.Upgrade();
        numberBullet += 2;
        currentReduceDB += reduceDB;
    }

    protected override T ChangeBullet<T>(T bullet) {
        T bulletChanged =  base.ChangeBullet(bullet);
        bulletChanged.HitInfor.Damage.AddModifier(new StatModifier(currentReduceDB, StatModType.PercentAdd));
        return bulletChanged;
    }

    protected override void Attacking() {
        FrontBullet bulletChanged = ChangeBullet<FrontBullet>(bullet);
        Vector2 directionShot = Vector2.up;
        FrontBullet goMid = PoolManager.Spawn(bulletChanged, (Vector2)firePoint.position, Quaternion.identity);
        goMid.SetHitInfor(bulletChanged);
        goMid.Shoot(speedBullet, directionShot);

        for (int ibullet = 0; ibullet < numberBullet / 2; ++ibullet) {
            Vector2 directionLeft = Helper.GamePlayHelper.RotateDirection(directionShot, spreadAngle * (ibullet + 1));
            FrontBullet goLeft = PoolManager.Spawn(bulletChanged, (Vector2)firePoint.position, Quaternion.identity);
            goLeft.SetHitInfor(bulletChanged);
            goLeft.Shoot(speedBullet, directionLeft);

            Vector2 directionRight = Helper.GamePlayHelper.RotateDirection(directionShot, -1 * spreadAngle * (ibullet + 1));
            FrontBullet goRight = PoolManager.Spawn(bulletChanged, (Vector2)firePoint.position, Quaternion.identity);
            goRight.SetHitInfor(bulletChanged);
            goRight.Shoot(speedBullet, directionRight);
        }

        PoolManager.Recycle(bulletChanged);
        EndAttacking();
    }
}
