using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    [SerializeField] private TargetType[] targetTypes;
    [SerializeField] protected float BDPercent; 
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ParticleSystem selfExplosion;
    [SerializeField, ColorUsage(true)] private Color selfDestroyColor;
    public Action onDestroy;

    protected IntStat damage;
    protected FloatStat size;
    protected bool isHitted;

    public IntStat Damage { get => damage; }
    public FloatStat Size { get => size; }

    protected virtual void OnEnable() {
        isHitted = false;
        GetComponent<Collider2D>().enabled = true;
    }

    public void SetAlpha(float alpha) {
        var color = sprite.color;
        color.a = alpha;
        sprite.color = color;
    }

    public void SetDamage(int atk) {
        damage = new IntStat((int)(atk * BDPercent));
    }

    public void SetSize(float size)
    {
        this.size.BaseValue = size;
        transform.localScale = Vector3.one * this.size.Value;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) {
        if (IsBlockHit()) {
            return;
        }
        foreach (var target in targetTypes) {
            if (target.ToString().Equals(collision.tag)) {
                Hit(collision);
                return;
            }
        }
        if (collision.CompareTag("Destroy") || collision.CompareTag("Finish")) {
            Destroy();
        }
    }

    protected virtual bool IsBlockHit() {
        return isHitted;
    }

    protected virtual void Hit(Collider2D collision) {
        isHitted = true;
        GetComponent<Collider2D>().enabled = false;
        CharacterTakeHit victim = collision.GetComponent<CharacterTakeHit>();
        if (victim != null) {
            victim.TakeHitDamege(Damage.Value);
        }
        DestroyWithEffect();
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
