using System.Collections;
using UnityEngine;

public class PlayerBasicComponent : PlayerAttackComponent {
    [SerializeField] private FrontBullet bullet;
    [SerializeField] private float speedBullet;

    private int numberBullet;
    public override void Initalize() {
        base.Initalize();
    }


    protected override void Attacking() {
        Vector2 directionShot = Vector2.up;
        FrontBullet goLeft = Instantiate(bullet, firePoint.position, Quaternion.identity);
        goLeft.Shoot(speedBullet, directionShot);
        EndAttacking();
    }
}

