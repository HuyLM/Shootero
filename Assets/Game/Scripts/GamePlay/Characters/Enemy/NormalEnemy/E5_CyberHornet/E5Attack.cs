using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E5Attack : EnemyAttack {
    private E5Base e5Base;
    public E5Base E5Base {
        get {
            if (e5Base == null) {
                e5Base = GetComponent<E5Base>();
            }
            return e5Base;
        }
    }

    [SerializeField] private Transform target;
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
        yield return new WaitForSeconds(delayAttack);
        for (int i = 0; i < numberShot; ++i) {
            Vector2 directionShot = target.position - transform.position;
            FrontBullet centerBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            centerBullet.Shoot(speedBullet, directionShot);
            for (int ibullet = 0; ibullet < numberBullet / 2; ++ibullet) {
                Vector2 leftDirectionShot = Helper.GamePlayHelper.RotateDirection(directionShot, spreadAngle * (ibullet + 1));
                FrontBullet leftBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                leftBullet.Shoot(speedBullet, leftDirectionShot);

                Vector2 rightDirectionShot = Helper.GamePlayHelper.RotateDirection(directionShot, -1 * spreadAngle * (ibullet + 1));
                FrontBullet rightBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                rightBullet.Shoot(speedBullet, rightDirectionShot);
            }

            yield return new WaitForSeconds(deltaShot);
        }

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
        E5Base.MoverE5.LookTarget(target.position);
    }
}
