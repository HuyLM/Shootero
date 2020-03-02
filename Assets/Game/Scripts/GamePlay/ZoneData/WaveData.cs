using UnityEngine;
using System;
using Helper;

[Serializable]
public class WaveData {
    [SerializeField] private DifficultWave difficult;
    [SerializeField] private RangeIntValue rangeTime;
    [SerializeField] private RangeIntValue rangeLimit;
    [SerializeField] private int enemyIds;
    [SerializeField] private float difficultMultiplier;
    [SerializeField] private RangeIntValue rangeChip;

    private int time;
    private int limit;
    private int chip;

    public DifficultWave Difficult { get => difficult; }
    public int EnemyIds { get => enemyIds; }
    public float DifficultMultiplier { get => difficultMultiplier; }
    public int Time { get => time; }
    public int Limit { get => limit; }
    public int Chip { get => chip; }


    public void Initalize() {
        time = RandomHelper.RandomInRange(rangeTime);
        limit = RandomHelper.RandomInRange(rangeLimit);
        chip = RandomHelper.RandomInRange(rangeChip);
    }
}


public enum DifficultWave {
    Easy, Hard, Hell
}
