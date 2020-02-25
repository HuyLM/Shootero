using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSkill : MonoBehaviour
{
    private PlayerBase characterBase;
    public PlayerBase CharacterBase {
        get {
            if (characterBase == null) {
                characterBase = GetComponent<PlayerBase>();
            }
            return characterBase;
        }
    }

    private List<ModData> mods = new List<ModData>();
    private List<IChangeBulletModable> changeBulletMods;

    public void Initalize() {

    }

    public void Countdown() {

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

        return null;
    }
}
