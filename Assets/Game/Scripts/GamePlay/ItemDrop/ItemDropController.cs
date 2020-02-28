using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemDropController : MonoBehaviour {
    [SerializeField] protected float startVelocity;
    [SerializeField] protected float acceleration;
    [SerializeField] protected Collider2D findTargetHitBox;
    [SerializeField] protected Collider2D hitTargetHitBox;

    private bool isFoundTarget;

    public virtual void Initalize() {
        isFoundTarget = false;
        findTargetHitBox.enabled = true;
        hitTargetHitBox.enabled = false;
        StopAllCoroutines();

    }

    public abstract void AddToPlayer(PlayerBase player);

    public virtual void MoveToPlayer(PlayerBase player) {
        StartCoroutine(IMoveToTarget(player.transform));
    }

    private IEnumerator IMoveToTarget(Transform target) {
        float v0 = startVelocity;
        float a = acceleration;
        float t = 0f;
        float v;
        while(true) {
            v = v0 + a * t;
            transform.position = Vector2.MoveTowards(transform.position, target.position, v * Time.fixedDeltaTime);
            t += Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D collider) {
        if(collider.CompareTag("Player")) {
            PlayerTakeHit takehit = collider.GetComponent<PlayerTakeHit>();
            if(takehit != null) {
                if(isFoundTarget) {
                    AddToPlayer(takehit.PlayerBase);
                    Destroy();
                }
                else {
                    isFoundTarget = true;
                    findTargetHitBox.enabled = false;
                    hitTargetHitBox.enabled = true;
                    MoveToPlayer(takehit.PlayerBase);
                }
            }
        }
    }

    public void Destroy() {
        PoolManager.Recycle(gameObject);
    }
}
