using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ConquerorData", menuName = "Resource/ConquerorData")]
public class ConquerorData : ScriptableObject {
    [SerializeField] private ZoneData[] zones;

    public ZoneData[] Zones { get => zones; }
}
