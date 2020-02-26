using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
public class HitInfor
{
    private IntStat damage;
    private List<IEffectAttackModable> effects = new List<IEffectAttackModable>();
    private CharacterBase causer;

    public IntStat Damage { get => damage; }
    public List<IEffectAttackModable> Effects { get => effects; }
    public CharacterBase Causer { get => causer; }

    public HitInfor(int damageBase, List<IEffectAttackModable> effects, CharacterBase causer) {
        damage = new IntStat(damageBase);
        this.effects = effects;
        this.causer = causer;
    }

    public HitInfor(HitInfor hit) {
        damage = new IntStat(hit.damage);
        this.effects = hit.effects;
        this.causer = hit.causer;
    }
}
