using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGatlingGunComponent : PlayerAttackComponent {
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;
    [SerializeField] private float halfSpreadAngle;
    [SerializeField] private float reduceDB = 0.1f;

    private int numberBullet;

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
        Debug.Log("reduce: " + reduceDB);
    }

    protected override void Attacking() {
        Vector2 directionShot = Vector2.up;

        for (int ibullet = 0; ibullet < numberBullet; ++ibullet) {
            Vector2 directionRandom = Helper.GamePlayHelper.RotateDirection(directionShot, Random.Range(-halfSpreadAngle, halfSpreadAngle));
            FrontBullet go = Instantiate(bullet, (Vector2)firePoint.position, Quaternion.identity);
            go.Shoot(speedBullet, directionRandom);
        }
        EndAttacking();
    }
}
