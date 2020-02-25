using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSplitterComponent : PlayerAttackComponent {
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;
    [SerializeField] private float spreadAngle;
    [SerializeField] private float reduceDB = 0.1f;

    private int numberBullet;

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
        Debug.Log("reduce: " + reduceDB);
    }

    protected override void Attacking() {
        Vector2 directionShot = Vector2.up;
        FrontBullet goMid = Instantiate(bullet, (Vector2)firePoint.position, Quaternion.identity);
        goMid.Shoot(speedBullet, directionShot);

        for (int ibullet = 0; ibullet < numberBullet / 2; ++ibullet) {
            Vector2 directionLeft = Helper.GamePlayHelper.RotateDirection(directionShot, spreadAngle * (ibullet + 1));
            FrontBullet goLeft = Instantiate(bullet, (Vector2)firePoint.position, Quaternion.identity);
            goLeft.Shoot(speedBullet, directionLeft);

            Vector2 directionRight = Helper.GamePlayHelper.RotateDirection(directionShot, -1 * spreadAngle * (ibullet + 1));
            FrontBullet goRight = Instantiate(bullet, (Vector2)firePoint.position, Quaternion.identity);
            goRight.Shoot(speedBullet, directionRight);
        }
        EndAttacking();
    }
}
