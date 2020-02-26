using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSkill : CharacterSkill
{
    private PlayerBase playerBase;
    public PlayerBase PlayerBase {
        get {
            if (playerBase == null) {
                playerBase = GetComponent<PlayerBase>();
            }
            return playerBase;
        }
    }


    private List<ModData> mods = new List<ModData>();
    private List<IChangeBulletModable> changeBulletMods = new List<IChangeBulletModable>();
    private List<IEffectAttackModable> effectAttackMods = new List<IEffectAttackModable>();

    public List<IChangeBulletModable> ChangeBulletMods { get => changeBulletMods; }
    public List<IEffectAttackModable> EffectAttackMods { get => effectAttackMods; }


    public override void Initalize() {
        base.Initalize();
    }

    public override void Countdown() {
        base.Countdown();
    }

    public void AddModData(ModData mod) {
        mods.Add(mod);
    }

    public bool HasMod(ModData mod) {
        return mods.Contains(mod);
    }

    public ModInfor GetModInfor(int id) {
        IChangeBulletModable changeBulletMod = changeBulletMods.FirstOrDefault(item => item.GetModInfor().GetId() == id);
        if(changeBulletMod != null) {
            return changeBulletMod.GetModInfor();
        }

        IEffectAttackModable effectAttackMod = effectAttackMods.FirstOrDefault(item => item.GetModInfor().GetId() == id);
        if(effectAttackMod != null) {
            return effectAttackMod.GetModInfor();
        } 
        return null;
    }

    public T GetModInfor<T>(int id) where T : ModInfor{
        IChangeBulletModable changeBulletMod = changeBulletMods.FirstOrDefault(item => item.GetModInfor().GetId() == id && item.GetType() == typeof(T));
        if(changeBulletMod != null) {
            return changeBulletMod.GetModInfor() as T;
        }

        IEffectAttackModable effectAttackMod = effectAttackMods.FirstOrDefault(item => item.GetModInfor().GetId() == id && item.GetType() == typeof(T));
        if(effectAttackMod != null) {
            return effectAttackMod.GetModInfor() as T;
        }
        return null;
    }

    public void AddChangeBulletMod(IChangeBulletModable mod) {
        changeBulletMods.Add(mod);
    }

    public void AddEffectAttackMods(IEffectAttackModable mod) {
        effectAttackMods.Add(mod);
    }
}
