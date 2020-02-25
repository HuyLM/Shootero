
public abstract class EffectAttackModData : ModData
{
}

public abstract class EffectAttackModInfor<T> : ModInfor<T> where T : EffectAttackModData{
    public abstract void EffectTo(CharacterBase victim, CharacterBase causer, int damageBase);
}
