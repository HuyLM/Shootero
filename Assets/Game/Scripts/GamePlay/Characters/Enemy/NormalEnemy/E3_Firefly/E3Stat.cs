using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3Stat : EnemyStat
{
    [SerializeField] private float atkSpeed = 1;

    public float AtkSpeed {
        get => atkSpeed;
    }
}
