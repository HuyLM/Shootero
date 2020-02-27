using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E6Attack : EnemyAttack {
    private E6Base e6Base;
    public E6Base E6Base {
        get {
            if (e6Base == null) {
                e6Base = GetComponent<E6Base>();
            }
            return e6Base;
        }
    }

    [SerializeField] private Transform target;
    [SerializeField] private float delayAttack;
    [SerializeField] private int numberShot;
    [SerializeField] private float deltaShot;
    [SerializeField] private HomingBullet bullet;
    [SerializeField] private float speedBullet;
    [SerializeField] private float size;
    private bool isAttacking;


    public override void Attack() {
        isAttacking = true;
        StartCoroutine(Attacking());

    }

    private IEnumerator Attacking() {
        yield return new WaitForSeconds(delayAttack);
        for (int i = 0; i < numberShot; ++i) {
            Vector2 directionShot = target.position - transform.position;
            HomingBullet centerBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            centerBullet.Shoot(speedBullet, target, directionShot);
            centerBullet.SetSize(size);
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
        E6Base.MoverE6.LookTarget(target.position);
    }
}
