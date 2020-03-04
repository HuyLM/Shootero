using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using System;
[CreateAssetMenu(fileName = "ModGenerator", menuName = "Resource/ModGenerator")]
public class ModGenerator : ScriptableObject {
    [SerializeField] private ModData[] attackMods;
    [SerializeField] private ModData[] allMods;
    [SerializeField] private ModSlot[] slot;

    private List<ModData> useableMods;
    private List<ModData> useableAttackMods;

    private void GetUseableMods() {
        PlayerBase player = GameManager.Instance.GameLoader.Player;
        useableMods = new List<ModData>();
        foreach(var mod in allMods) {
            if(mod.CanApplyTo(player)) {
                useableMods.Add(mod);
            }
        }

        useableAttackMods = new List<ModData>();
        foreach(var mod in attackMods) {
            if(mod.CanApplyTo(player)) {
                useableAttackMods.Add(mod);
            }
        }
    }
    private List<ModData> GetModsByRarity(ModRarity rarity) {
        List<ModData> mods = new List<ModData>();
        foreach(var mod in useableMods) {
            if(mod.rarity == rarity) {
                mods.Add(mod);
            }
        }
        return mods;
    }
    private ModData GetRandomModDataByRarity(ModRarity rarity) {
        List<ModData> mods = GetModsByRarity(rarity);
        return RandomHelper.RandomInCollection(mods);
    }

    public ModData[] GetRandomModDatas(bool isGetAttackMod) {
        ModData[] randomMods;
        GetUseableMods();
        if(isGetAttackMod && false) {
            randomMods = RandomHelper.RandomInCollection(useableAttackMods.ToArray(), slot.Length);
        }
        else {
            randomMods = new ModData[slot.Length];
            for(int i = 0; i < slot.Length; ++i) {
                ModRarity randomRarity = slot[i].GetRandomRarity();
                ModData randomModData = GetRandomModDataByRarity(randomRarity);
                randomMods[i] = randomModData;
            }
        }
        RandomHelper.Shuffle(randomMods);
        return randomMods;
    }

    [Serializable]
    public class ModSlot {
        [SerializeField] private ModRarity[] rarities;

        public ModRarity GetRandomRarity() {
            return RandomHelper.RandomInCollection(rarities);
        }


    }
}
