using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5Attack : EnemyAttack {
    private E5Base e5Base;
    public E5Base E5Base {
        get {
            if(e5Base == null) {
                e5Base = GetComponent<E5Base>();
            }
            return e5Base;
        }
    }

    [SerializeField] private float delayAttack;
    [SerializeField] private int numberShot;
    [SerializeField] private float deltaShot;
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;
    [SerializeField] private int numberBullet;
    [SerializeField] private float spreadAngle;
    private bool isAttacking;


    public override void Attack() {
        isAttacking = true;
        StartCoroutine(Attacking());

    }

    private IEnumerator Attacking() {
        FrontBullet bulletChanged = ChangeBullet<FrontBullet>(bullet);
        yield return new WaitForSeconds(delayAttack);
        for(int i = 0; i < numberShot; ++i) {
            Vector2 directionShot = Target.position - transform.position;
            FrontBullet centerBullet = PoolManager.Spawn(bulletChanged, transform.position, Quaternion.identity);
            centerBullet.SetHitInfor(bulletChanged);
            centerBullet.Shoot(speedBullet, directionShot);
            for(int ibullet = 0; ibullet < numberBullet / 2; ++ibullet) {
                Vector2 leftDirectionShot = Helper.GamePlayHelper.RotateDirection(directionShot, spreadAngle * (ibullet + 1));
                FrontBullet leftBullet = PoolManager.Spawn(bulletChanged, transform.position, Quaternion.identity);
                leftBullet.SetHitInfor(bulletChanged);
                leftBullet.Shoot(speedBullet, leftDirectionShot);

                Vector2 rightDirectionShot = Helper.GamePlayHelper.RotateDirection(directionShot, -1 * spreadAngle * (ibullet + 1));
                FrontBullet rightBullet = PoolManager.Spawn(bulletChanged, transform.position, Quaternion.identity);
                rightBullet.SetHitInfor(bulletChanged);
                rightBullet.Shoot(speedBullet, rightDirectionShot);
            }
            yield return new WaitForSeconds(deltaShot);
        }
        PoolManager.Recycle(bulletChanged);
        isAttacking = false;
    }

    public override bool CanAttack() {
        return !isAttacking;
    }

    public bool IsAttacking() {
        return isAttacking;
    }

    public override void Countdown() {
        base.Countdown();
    }

    public void AimTarget() {
        E5Base.MoverE5.LookTarget(Target.position);
    }
}
