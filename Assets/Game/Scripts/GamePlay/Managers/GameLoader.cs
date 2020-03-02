using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;
using System;

public class GameLoader : MonoBehaviour
{
    [SerializeField] private PlayerBase player;
    [SerializeField] private Vector3 positionSpawn;
    private List<EnemyBase> enemies;



    public PlayerBase Player { get => player; }
    public List<EnemyBase> Enemies { get => enemies; }

    public EnemyBase SpawnEnemy(DifficultWave difficult)
    {
        Tuple<EnemyType, int>[] randomType = new Tuple<EnemyType, int>[3];
        switch(difficult)
        {
            case DifficultWave.Easy:
                {
                    randomType[0] = new Tuple<EnemyType, int>(EnemyType.Normal, 80);
                    randomType[1] = new Tuple<EnemyType, int>(EnemyType.Elite, 20);
                    randomType[2] = new Tuple<EnemyType, int>(EnemyType.Champion, 0);
                    break;
                }
            case DifficultWave.Hard:
                {
                    randomType[0] = new Tuple<EnemyType, int>(EnemyType.Normal, 40);
                    randomType[1] = new Tuple<EnemyType, int>(EnemyType.Elite, 40);
                    randomType[2] = new Tuple<EnemyType, int>(EnemyType.Champion, 20);
                    break;
                }
            case DifficultWave.Hell:
                {
                    randomType[0] = new Tuple<EnemyType, int>(EnemyType.Normal, 10);
                    randomType[1] = new Tuple<EnemyType, int>(EnemyType.Elite, 50);
                    randomType[2] = new Tuple<EnemyType, int>(EnemyType.Champion, 40);
                    break;
                }
            default:
                {
                    break;
                }
        }

        
    }

    private List<EnemyBase> GetAllEnemyType(EnemyType type)
    {

    }

    public EnemyBase SpawnEnemy(EnemyBase enemy)
    {
        EnemyBase e = PoolManager.Spawn(enemy, transform, positionSpawn);
        enemies.Add(e);
        return e;
    }

    public void RemoveEnemy(EnemyBase enemy)
    {
        enemies.Remove(enemy);
        GameManager.Instance.CalculationDelaySpawnEnemy();
    }

}
