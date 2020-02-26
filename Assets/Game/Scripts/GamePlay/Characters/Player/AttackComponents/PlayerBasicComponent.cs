using System.Collections;
using UnityEngine;

public class PlayerBasicComponent : PlayerAttackComponent {
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;

    private int numberBullet;

    public override void FocusUpgrade() {
    }

    public override void Initalize() {
        base.Initalize();
    }


    protected override void Attacking() {
        FrontBullet bulletChanged = ChangeBullet<FrontBullet>(bullet);
        Vector2 directionShot = Vector2.up;
        FrontBullet go = PoolManager.Spawn(bulletChanged, firePoint.position, Quaternion.identity);
        go.SetHitInfor(bulletChanged);
        go.Shoot(speedBullet, directionShot);
        PoolManager.Recycle(bulletChanged);
        EndAttacking();
    }
}

