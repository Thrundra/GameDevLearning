using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "EnemyWaveAmount")]
public class WaveEnemyAmount : ScriptableObject {

    [SerializeField] EnemyData enemyData;
    [SerializeField] int numberOfEnemiesInWave;

    public int GetEnemiesInWave()
    {
        return numberOfEnemiesInWave;
    }

    public GameObject GetEnemyPrefab()
    {
        return enemyData.GetEnemyPrefab();
    }

}
