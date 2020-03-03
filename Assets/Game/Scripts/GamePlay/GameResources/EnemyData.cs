using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helper;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Resource/EnemyData")]
public class EnemyData : ScriptableObject {
    [SerializeField] private EnemySpecies[] enemies;

    public List<EnemySpecies> GetEnemySpeciesByIndex(int[] indexs) {
        List<EnemySpecies> es = new List<EnemySpecies>();
        for(int i = 0; i < indexs.Length; ++i) {
            es.Add(enemies[indexs[i] - 1]);
        }
        return es;
    }

    private EnemySpecies GetEnemySpeciesRandom(int[] indexs) {
        List<EnemySpecies> es = GetEnemySpeciesByIndex(indexs);
        return RandomHelper.RandomInList(es);
    }

    public EnemyBase GetEnemyBaseRandom(int[] indexs, EnemyType type) {
        EnemySpecies species = GetEnemySpeciesRandom(indexs);
        List<EnemyBase> enemyOnlyTypes = new List<EnemyBase>();
        foreach(EnemyBase enemyBase in species.enemies) {
            if(enemyBase.Type == type) {
                enemyOnlyTypes.Add(enemyBase);
            }
        }
        return RandomHelper.RandomInList(enemyOnlyTypes);
    }

    [System.Serializable]
    public class EnemySpecies {
        public EnemyBase[] enemies;
    }

}
