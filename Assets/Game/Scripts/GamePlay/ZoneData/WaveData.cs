using UnityEngine;
using System;
using Helper;

[Serializable]
public class WaveData {
    [SerializeField] private DifficultWave difficult;
    [SerializeField] private RangeIntValue rangeTime;
    [SerializeField] private RangeIntValue rangeLimit;
    [SerializeField] private int[] enemyIds;
    [SerializeField] private float difficultMultiplier;
    [SerializeField] private RangeIntValue rangeChip;

    private int time;
    private int limit;
    private int chip;
    private int icon;
    private int spawnedIcon;

    public DifficultWave Difficult { get => difficult; }
    public int[] EnemyIds { get => enemyIds; }
    public float DifficultMultiplier { get => difficultMultiplier; }
    public int Time { get => time; }
    public int Limit { get => limit; }
    public int Chip { get => chip; }
    public RangeIntValue RangeChip { get => rangeChip; }
    public int Icon { get => icon; }
    public int SpawnedIcon { get => spawnedIcon; set => spawnedIcon = value; }
    public int RemainingIcon { get => (icon - spawnedIcon); }

    public void Initalize() {
        time = RandomHelper.RandomInRange(rangeTime);
        limit = RandomHelper.RandomInRange(rangeLimit);
        chip = GetChipInWave();
        icon = chip / GetChipInIcon();
        spawnedIcon = 0;
    }

    private int GetChipInWave() {
        int chipPerIcon = GetChipInIcon();
        int randomChip = RandomHelper.RandomInRange(rangeChip);
        randomChip = (randomChip / chipPerIcon) * chipPerIcon;
        if(randomChip < GameManager.Instance.CurrentWaveData.RangeChip.min) {
            randomChip = (randomChip / chipPerIcon + 1) * chipPerIcon;
        }
        return randomChip;
    }


    public int GetChipInIcon() {
        if(true) {
            return (int)(5 * (0.8f + 0.2f * (GameManager.Instance.CurrentZoneIndex + 1)));
        }
        else {
            return 5;
        }
    }
}


public enum DifficultWave {
    Easy, Hard, Hell
}
