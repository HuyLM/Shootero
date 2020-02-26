using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BurnShotModData", menuName = "ModData/EffectAttack/BurnShot")]
public class BurnShotModData : EffectAttackModData {
    public float duration;
    public float deltaBurn;
    public float damagePercent;

    public override void ApplyTo(PlayerBase character) {
        base.ApplyTo(character);
        BurnShotModInfor burnInfor = new BurnShotModInfor(this);
        character.SkillerPlayer.AddEffectAttackMods(burnInfor);
    }
}


public class BurnShotModInfor : EffectAttackModInfor<BurnShotModData> {
    private FloatStat duration;
    private FloatStat deltaBurn;
    private FloatStat damagePercent;


    public BurnShotModInfor(BurnShotModData mod) : base(mod) {
        duration = new FloatStat(mod.duration);
        deltaBurn = new FloatStat(mod.deltaBurn);
        damagePercent = new FloatStat(mod.damagePercent);

    }

    protected BurnShotModInfor(BurnShotModInfor mod) : base(mod) {
        this.modData = mod.modData;
        this.currentStack = mod.currentStack;
        duration = new FloatStat(mod.duration);
        deltaBurn = new FloatStat(mod.deltaBurn);
        damagePercent = new FloatStat(mod.damagePercent);
    }

    public FloatStat Duration { get => duration; }
    public FloatStat DeltaBurn { get => deltaBurn; }
    public FloatStat DamagePercent { get => damagePercent; }

    public override object Clone() {
        return new BurnShotModInfor(this);
    }

    public override void EffectTo(CharacterBase victim, CharacterBase causer, IntStat damageStat) {
        BurnEffect effect = new BurnEffect(victim, causer, duration.Value, deltaBurn.Value, (int)(damageStat.BaseValue * damagePercent.Value));
        victim.SkillerBase.AddCountdownEffect(effect);
    }
}