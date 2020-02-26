using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGatlingGunComponent : PlayerAttackComponent {
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;
    [SerializeField] private float halfSpreadAngle;
    [SerializeField] private float reduceDB = 0.1f;

    private int numberBullet;
    private float currentReduceDB = 0f;

    public override void FocusUpgrade() {
        halfSpreadAngle = 6;
    }

    public override void Initalize() {
        base.Initalize();
        numberBullet = 1;
    }

    [ContextMenu("upgrade")]
    public override void Upgrade() {
        base.Upgrade();
        numberBullet += 1;
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
        for (int ibullet = 0; ibullet < numberBullet; ++ibullet) {
            Vector2 directionRandom = Helper.GamePlayHelper.RotateDirection(directionShot, Random.Range(-halfSpreadAngle, halfSpreadAngle));
            FrontBullet go = Instantiate(bulletChanged, (Vector2)firePoint.position, Quaternion.identity);
            go.SetHitInfor(bulletChanged);
            go.Shoot(speedBullet, directionRandom);
        }
        PoolManager.Recycle(bulletChanged);
        EndAttacking();
    }
}
