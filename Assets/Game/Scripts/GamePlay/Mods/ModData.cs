using UnityEngine;


public abstract class ModData : ScriptableObject {
    public int modId;
    public ModType type;
    [Range(0, 5)] public int rarity;
    public int maxStack = 1;
    public ModData[] requireMods;
    public ModData[] aMods;

    public bool CanApplyTo(PlayerBase character) {
        foreach(ModData mod in requireMods) {
            if(!character.SkillerPlayer.HasMod(mod)) {
                return false;
            }
        }

        foreach(ModData mod in aMods) {
            if(character.SkillerPlayer.HasMod(mod)) {
                return false;
            }
        }

        ModInfor modInfor = character.SkillerPlayer.GetModInfor(modId);
        if(modInfor != null) {
            if(modInfor.CurrentStack >= maxStack) {
                return false;
            }
        }
        return true;
    }
    public virtual void ApplyTo(PlayerBase character) {
        character.SkillerPlayer.AddModData(this);
    }
    //public virtual void AddDuplicate(CharacterBase character, ModInfor skillInfor = null) {
    //    skillInfor.Upgrade();
    //    character.SkillerBase.AddModData(this);
    //}
    public override bool Equals(object other) {
        if(other == null) {
            return false;
        }
        return this.modId == (other as ModData).modId;
    }

    public override int GetHashCode() {
        return this.modId.GetHashCode();
    }
}

public abstract class ModInfor {
    protected int currentStack;
    public int CurrentStack { get => currentStack; }

    public ModInfor() {
        currentStack = 0;
    }

    public ModInfor(ModInfor mod) {
        currentStack = mod.currentStack;
    }

    public virtual void Upgrade() {
        currentStack++;
    }

    public virtual void Downgrade() {
        if (CurrentStack <= 1) {
            return;
        }
        currentStack--;
    }

    public abstract int GetId();
}

public interface IModable : System.ICloneable {
    ModInfor GetModInfor();
}

public abstract class ModInfor<T> : ModInfor where T : ModData {
    protected T modData;

    public ModInfor(T modData) {
        this.modData = modData;
    }

    public ModInfor(ModInfor<T> mod) : base(mod) {
        this.modData = mod.modData;
    }
   
    public override sealed int GetId() {
        return modData.modId;
    }
}



public enum ModType {
    Offense, Deffense, Utility
}

