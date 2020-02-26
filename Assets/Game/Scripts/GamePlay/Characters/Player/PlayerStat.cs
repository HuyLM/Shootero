using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : CharacterStat
{
    [SerializeField] private FloatStat atkSpeed;

    public FloatStat AtkSpeed { get => atkSpeed; }
}
