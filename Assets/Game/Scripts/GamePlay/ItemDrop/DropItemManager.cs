using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;


public class DropItemManager : SingletonBind<DropItemManager> {

    [SerializeField] private ChipDropController chipPrefab;
    [SerializeField] private float chipRadius;

    [SerializeField] private float fakePercentPerEnemy;
    [SerializeField] private bool fakeIsInTimeWave;
    [SerializeField] private int currentEnemy;
    [SerializeField] private int currentChipNumber;


    [Header("wave")]
    [SerializeField] private RangeIntValue fakeRandomChipNumber;

    [Header("Zone")]
    [SerializeField] private int fakeCurrentZoneIndex;

    [Header("player")]
    [SerializeField] private PlayerBase fakePlayerbase;

    [Header("GamePlay")]
    [SerializeField] private bool fakeIsInConqueror = true;


    public void SpawnChip(Vector2 position) {
        if(RandomHelper.RandomWithPercent(fakePercentPerEnemy)) {
            int chipNumber = 1;
            if(fakeIsInTimeWave) {
                if(RandomHelper.RandomWithPercent(50)) {
                    chipNumber = 1;
                }
                else {
                    chipNumber = 2;
                }
            }
            else {
                chipNumber = Mathf.CeilToInt(currentChipNumber / (currentEnemy + 1));
            }
            for(int i = 0; i < chipNumber; ++i) {
                SpawnChip(position, chipRadius);
            }
        }
    }


    private void SpawnChip(Vector2 position, float radius) {
        Vector2 positionRandom = position + Random.insideUnitCircle * radius;
        ChipDropController chipDrop = PoolManager.Spawn(chipPrefab, positionRandom);
        chipDrop.SetChipNumber(GetChipInIcon());
        currentChipNumber--;
    }

    private int GetMaxIconInWave() {
        int chipPerIcon = GetChipInIcon();
        int randomChip = RandomHelper.RandomInRange(fakeRandomChipNumber);
        int maxChipInWave = (randomChip / chipPerIcon) * chipPerIcon;
        if(maxChipInWave < fakeRandomChipNumber.min) {
            maxChipInWave = (randomChip / chipPerIcon + 1) * chipPerIcon;
        }
        return maxChipInWave;
    }

    private int GetChipInIcon() {
        if(fakeIsInConqueror) {
            return (int)(5 * (0.8f + 0.2f * (fakeCurrentZoneIndex + 1)));
        }
        else {
            return 5;
        }
    }
}
