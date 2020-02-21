using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] private TargetType[] targetTypes;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ParticleSystem selfExplosion;
    [SerializeField, ColorUsage(true)] private Color selfDestroyColor;
    public Action onDestroy;

    private int damage;
    private bool isHitted;

    protected virtual void OnEnable() {
        isHitted = false;
        GetComponent<Collider2D>().enabled = true;
    }

    public void SetDamage(int damage) {
        this.damage = damage;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (isHitted) {
            return;
        }
        foreach (var target in targetTypes) {
            if (target.ToString().Equals(collision.tag)) {
                isHitted = true;
                GetComponent<Collider2D>().enabled = false;
                CharacterTakeHit victim = collision.GetComponent<CharacterTakeHit>();
                if (victim != null) {
                    victim.TakeHitDamege(damage);
                }
                DestroyWithEffect();
                return;
            }
        }
        if (collision.CompareTag("Destroy") || collision.CompareTag("Finish")) {
            Destroy();
        }
    }

    protected virtual void DestroyWithEffect() {
        if (explosion != null) {
            PoolManager.Spawn(explosion, transform.position);
        }
        onDestroy?.Invoke();
        PoolManager.Recycle(gameObject);
    }

    protected virtual void Destroy() {
        onDestroy?.Invoke();
        PoolManager.Recycle(gameObject);
    }

    public virtual void SelfDestroy() {
        if (selfExplosion != null) {
            ParticleSystem effect = PoolManager.Spawn(selfExplosion, transform.position);
            ParticleSystem.MainModule main = effect.main;
            main.startColor = selfDestroyColor;
            effect.Play();
        }
        onDestroy?.Invoke();
        PoolManager.Recycle(gameObject);
    }

    public enum TargetType {
        Player, Enemy, ShieldEnemy
    }
}
