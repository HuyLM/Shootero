using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBind<GameManager>
{
    [SerializeField] private GameLoader gameLoader;

    [SerializeField] private int currentZoneIndex;
    [SerializeField] private int currentWaveIndex;

    private float countdownSpawnTime = -1;
    private float countdownSpawnEnemies = -1f;
    private bool canSpawnEnemies = true;
    public WaveData CurrentWaveData
    {
        get
        {
            return GameResource.Instance.ConquerorData.Zones[currentZoneIndex].WaveDatas[currentZoneIndex];
        }
    }
    public void StartGame()
    {
        StartWave();
    }

    private void StartWave()
    {

    }

    public void CalculationDelaySpawnEnemy()
    {
        if(countdownSpawnTime > 0)
        {
            int currentE = gameLoader.Enemies.Count;
            int limitE = CurrentWaveData.Limit;
            float newDelaySpawn = (1.0f * currentE / limitE) * 3;
            if (countdownSpawnEnemies >= 0 && newDelaySpawn < countdownSpawnEnemies)
            {
                countdownSpawnEnemies = newDelaySpawn;
            }
        }
    }

    private void SpawnEnemies()
    {
        int limitE = CurrentWaveData.Limit;
        int currentE = gameLoader.Enemies.Count;
        int numberEnemyNeedSpawn = limitE - currentE;
        for(int i = 0; i < numberEnemyNeedSpawn; ++i)
        {
            gameLoader.SpawnEnemy();
        }
    }


    public void Win()
    {

    }

    public void Lose()
    {

    }

    public void Pause()
    {

    }

    private void Update()
    {
        if(countdownSpawnTime >= 0)
        {
            countdownSpawnTime -= Time.deltaTime;
        }

        if (countdownSpawnEnemies >= 0)
        {
            countdownSpawnEnemies -= Time.deltaTime;
            if(countdownSpawnEnemies < 0)
            {
                SpawnEnemies();
            }
        }
    }

}
