using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

[System.Serializable]
public abstract class Stat<T> {
    public T BaseValue;
    protected readonly List<StatModifier> statModifiers;
    public readonly ReadOnlyCollection<StatModifier> StatModifiers;

    private bool isDirty = true;
    private T _value;
    private T lastBaseValue;

    public Stat() {
        lastBaseValue = TMinValue();
        statModifiers = new List<StatModifier>();
        StatModifiers = statModifiers.AsReadOnly();
    }

    public Stat(T baseValue) : this() {
        BaseValue = baseValue;
    }


    public T Value {
        get {
            if (isDirty || !lastBaseValue.Equals(BaseValue)) {
                lastBaseValue = BaseValue;
                _value = CalculateFinalValue();
                isDirty = false;
            }
            return _value;
        }
    }

    public void AddModifier(StatModifier mod) {
        isDirty = true;
        statModifiers.Add(mod);
        statModifiers.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(StatModifier mod) {
        if (statModifiers.Remove(mod)) {
            isDirty = true;
            return true;
        }
        return false;
    }

    public bool RemoveAllModifiersFromSource(object source) {
        bool didRemove = false;

        for (int i = statModifiers.Count - 1; i >= 0; i--) {
            if (statModifiers[i].Source == source) {
                isDirty = true;
                didRemove = true;
                statModifiers.RemoveAt(i);
            }
        }
        return didRemove;
    }

    protected abstract T CalculateFinalValue();

    protected abstract T TMinValue();


    private int CompareModifierOrder(StatModifier a, StatModifier b) {
        if (a.Order < b.Order)
            return -1;
        else if (a.Order > b.Order)
            return 1;
        return 0;
    }
}
