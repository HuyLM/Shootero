using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3Attack : EnemyAttack
{
    private E3Base e3Base;
    public E3Base E3Base {
        get {
            if (e3Base == null) {
                e3Base = GetComponent<E3Base>();
            }
            return e3Base;
        }
    }

    [SerializeField] private Transform target;
    [SerializeField] private float delayAttack;
    [SerializeField] private int numberShot;
    [SerializeField] private float deltaShot;
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;
    private float attackCountdown;
    private bool isAttacking;


    public void StartAttack() {
        attackCountdown = 1 / E3Base.StaterE3.AtkSpeed;
    }

    public override void Attack() {
        isAttacking = true;
        //E3Base.MoverE3.SetDirectionMove((Vector2)target.position - E3Base.MoverE3.MyRigi.position);
        StartCoroutine(Attacking());

    }

    private IEnumerator Attacking() {
        yield return new WaitForSeconds(delayAttack);
        for(int i = 0; i < numberShot; ++i) {
            FrontBullet goLeft = Instantiate(bullet, transform.position, Quaternion.identity);
            goLeft.Shoot(speedBullet, (Vector2)(target.position - transform.position)); 
            yield return new WaitForSeconds(deltaShot);
        }

        isAttacking = false;
    }

    public override bool CanAttack() {
        return attackCountdown < 0 && !isAttacking;
    }

    public bool IsAttacking() {
        return isAttacking;
    }

    public override void Countdown() {
        base.Countdown();
        if (attackCountdown >= 0) {
            attackCountdown -= Time.deltaTime;
        }
    }

    public void AimTarget() {
        E3Base.MoverE3.LookTarget(target.position);
    }
}
