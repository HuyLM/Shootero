using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChangeBulletModData : ModData
{
}

public abstract class ChangeBulletModInfor<T> : ModInfor<T>, IChangeBulletModable where T : ChangeBulletModData {
    public abstract void ChangeBullet(BulletBase bullet);

    public ModInfor GetModInfor() {
        return this;
    }
}

public interface IChangeBulletModable : IModable {
    void ChangeBullet(BulletBase bullet);
}
