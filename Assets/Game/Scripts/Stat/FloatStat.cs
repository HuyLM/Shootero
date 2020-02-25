
using System;

[Serializable]

public class FloatStat : Stat<float> {
    protected override float CalculateFinalValue() {
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

        return (float)Math.Round(finalValue, 4);
    }

    protected override float TMinValue() {
        return float.MinValue;
    }
}
