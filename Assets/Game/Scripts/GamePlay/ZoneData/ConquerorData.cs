using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ConquerorData", menuName = "ConquerorData")]
public class ConquerorData : ScriptableObject {
    [SerializeField] private ZoneData[] zones;

    public ZoneData[] Zones { get => zones; }
}
