using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : BulletBase
{
    [SerializeField] private float turn;
    [SerializeField] private float delayHoming;
    [SerializeField] private float timeHoming; 
    [SerializeField] private Rigidbody2D myRigi;
    private float speed;
    private bool isHoming;
    private float countdownHoming;

    private Transform myTransform;
    private Transform target;

    protected override void OnEnable()
    {
        base.OnEnable();
        myTransform = transform;
    }

    public void Shoot(float speed, Transform target, Vector2 direction)
    {
        this.speed = speed;
        this.target = target;
        isHoming = false;
        myTransform.up = direction;
        myRigi.velocity = myTransform.up * speed;
        StartCoroutine(HoldHoming());
    }

    public void Shoot(float speed, Transform target)
    {
        this.speed = speed;
        this.target = target;
        isHoming = false;
        myRigi.velocity = transform.up * speed;
        StartCoroutine(HoldHoming());

    }

    private IEnumerator HoldHoming()
    {
        yield return new WaitForSeconds(delayHoming);
        countdownHoming = timeHoming;
        isHoming = true;
    }



    public void FixedUpdate()
    {
        if (isHoming && target != null && countdownHoming > 0)
        {
            myRigi.velocity = myTransform.up * speed;
            Vector3 targetVector = target.position - myTransform.position;
            float rotatingIndex = Vector3.Cross(targetVector, transform.up).z;
            myRigi.angularVelocity = -1 * rotatingIndex * turn;
            countdownHoming -= Time.fixedDeltaTime;
        }
        else
        {
            myRigi.angularVelocity = 0;
            myTransform.up = myRigi.velocity;
        }
    }
}
