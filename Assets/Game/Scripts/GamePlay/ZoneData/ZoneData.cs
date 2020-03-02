using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneData {
    [SerializeField] private WaveData[] waveDatas;

    public WaveData[] WaveDatas { get => waveDatas; }
}
