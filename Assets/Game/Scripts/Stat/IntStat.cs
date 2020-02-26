
using System;

[Serializable]
public class IntStat : Stat<int> {
    public IntStat() : base() {

    }

    public IntStat(int value) : base(value){

    }

    public IntStat(Stat<int> stat) : base(stat) {

    }
    protected override int CalculateFinalValue() {
        float finalValue = BaseValue;
        float sumPercentAdd = 0;
        for (int i = 0; i < statModifiers.Count; i++) {
            StatModifier mod = statModifiers[i];
            if (mod.Type == StatModType.Flat) {
                finalValue += mod.Value;
            } else if (mod.Type == StatModType.PercentAdd) {
                sumPercentAdd += mod.Value;
                if (i + 1 >= statModifiers.Count || statModifiers[i + 1].Type != StatModType.PercentAdd) {
                    finalValue *= 1 + sumPercentAdd;
                    sumPercentAdd = 0;
                }
            } else if (mod.Type == StatModType.PercentMult) {
                finalValue *= 1 + mod.Value;
            }
        }

        return (int)finalValue;
    }

    protected override int TMinValue() {
        return int.MinValue;
    }
}
