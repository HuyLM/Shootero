﻿
public abstract class EffectAttackModData : ModData
{
}

public abstract class EffectAttackModInfor<T> : ModInfor<T>, IEffectAttackModable where T : EffectAttackModData {
    public EffectAttackModInfor(T mod) : base(mod) {

    }

    public EffectAttackModInfor(EffectAttackModInfor<T> mod) : base(mod) {

    }

    public abstract object Clone();

    public abstract void EffectTo(CharacterBase victim, CharacterBase causer, IntStat damageStat);
    public ModInfor GetModInfor() {
        return this;
    }
}

public interface IEffectAttackModable : IModable {
    void EffectTo(CharacterBase victim, CharacterBase causer, IntStat damageStat);
}
