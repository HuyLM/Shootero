using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using System;

public class GameLoader : MonoBehaviour {
    [SerializeField] private PlayerBase player;
    [SerializeField] private Vector3 positionSpawn = new Vector3(100, 100, 0);
    [SerializeField] private Transform enemyContainer;
    private List<EnemyBase> enemies = new List<EnemyBase>();



    public PlayerBase Player { get => player; }
    public List<EnemyBase> Enemies { get => enemies; }

    public void Initalize() {
        player.Initalize();
    }

    public EnemyBase SpawnEnemy(DifficultWave difficult, int[] enemyIds) {
        EnemyType type = RandomTypeEnemy(difficult);
        EnemyBase enemy = GameResource.Instance.EnemyData.GetEnemyBaseRandom(enemyIds, type);
        return SpawnEnemy(enemy);
    }

    public EnemyType RandomTypeEnemy(DifficultWave difficult) {
        EnemyType[] types = { EnemyType.Normal, EnemyType.Elite, EnemyType.Champion };
        int[] randomPercent = new int[3];
        switch(difficult) {
            case DifficultWave.Easy: {
                randomPercent[0] = 80;
                randomPercent[1] = 20;
                randomPercent[2] = 0;
                break;
            }
            case DifficultWave.Hard: {
                randomPercent[0] = 40;
                randomPercent[1] = 40;
                randomPercent[2] = 20;
                break;
            }
            case DifficultWave.Hell: {
                randomPercent[0] = 10;
                randomPercent[1] = 50;
                randomPercent[2] = 40;
                break;
            }
            default: {
                break;
            }
        }
        int randomTypeIndex = RandomHelper.RandomWithPercent(randomPercent);
        return types[randomTypeIndex];
    }


    public EnemyBase SpawnEnemy(EnemyBase enemy) {
        EnemyBase e = PoolManager.Spawn(enemy, enemyContainer, positionSpawn);
        e.Initalize();
        enemies.Add(e);
        return e;
    }

    public void RemoveEnemy(EnemyBase enemy) {
        enemies.Remove(enemy);
        PoolManager.Recycle(enemy);
        GameManager.Instance.CalculationDelaySpawnEnemy();
    }

}
