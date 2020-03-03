using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;


public class DropItemManager : SingletonBind<DropItemManager> {

    [SerializeField] private ChipDropController chipPrefab;
    [SerializeField] private float chipRadius;

    [SerializeField] private float fakePercentPerEnemy;


    [Header("GamePlay")]
    [SerializeField] private bool fakeIsInConqueror = true;


    public void SpawnChip(Vector2 position) {
        if(RandomHelper.RandomWithPercent(fakePercentPerEnemy)) {
            int chipNumber = 1;
            if(GameManager.Instance.IsInTimeSpawn) {
                if(RandomHelper.RandomWithPercent(50)) {
                    chipNumber = 1;
                }
                else {
                    chipNumber = 2;
                }
            }
            else {
                chipNumber = Mathf.CeilToInt(GameManager.Instance.CurrentWaveData.RemainingIcon / (GameManager.Instance.GameLoader.Enemies.Count + 1));
            }
            for(int i = 0; i < chipNumber; ++i) {
                SpawnChip(position, chipRadius);
            }
        }
    }


    private void SpawnChip(Vector2 position, float radius) {
        Vector2 positionRandom = position + Random.insideUnitCircle * radius;
        ChipDropController chipDrop = PoolManager.Spawn(chipPrefab, positionRandom);
        chipDrop.SetChipNumber(GameManager.Instance.CurrentWaveData.GetChipInIcon());
        GameManager.Instance.CurrentWaveData.SpawnedIcon++;
    }



}
