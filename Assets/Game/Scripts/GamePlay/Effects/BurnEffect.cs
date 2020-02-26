using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnEffect : CountdownEffect {
    public static string burnId = "burn";
    protected float deltaBurn;
    protected HitInfor hit;


    private float deltaBurnTimer;
    private bool startedBurn;

    public BurnEffect(CharacterBase victim, CharacterBase causer, float duration, float deltaAttack, int damage) : base(victim, causer, duration) {
        id = burnId;
        this.deltaBurn = deltaAttack;
        hit = new HitInfor(damage, new List<IEffectAttackModable>(), causer);
        deltaBurnTimer = 0;
    }

    private void StartBurn() {
        startedBurn = true;
    }

    public override void EffectTo() {
        StartBurn();
    }
    
    public override void AddDupllicate(List<CountdownEffect> effects) {
        base.AddDupllicate(effects);
    }

    protected override void RemoveFrom() {
        victim.SkillerBase.RemoveCountdownEffect(this);
    }

    private void Burn(HitInfor hit) {
        victim.TakeHitterBase.TakeHitDamage(hit);
        Debug.Log("Burn : " + hit.Damage.Value);
    }

    public override void Update(float deltaTime) {
        base.Update(deltaTime);
        if (startedBurn) {
            deltaBurnTimer -= deltaTime;
            if (deltaBurnTimer <= 0) {
                Burn(hit);
                deltaBurnTimer = deltaBurn;
            }
        }
    }
}
