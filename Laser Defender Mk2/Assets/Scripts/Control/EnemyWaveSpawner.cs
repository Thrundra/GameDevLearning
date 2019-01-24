using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour
{
    [SerializeField] List<EnemyWaveConfig> m_WaveList;
    [SerializeField] int m_StartingWaveIndex = 0;
    [SerializeField] bool b_isLooping = false;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (b_isLooping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int t_waveIndex = m_StartingWaveIndex; t_waveIndex < m_WaveList.Count; t_waveIndex++)
        {
            var m_currentWave = m_WaveList[t_waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(m_currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(EnemyWaveConfig m_currentWaveConfig)
    {
        for(int enemyCount = 0; enemyCount < m_currentWaveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var m_newEnemy = Instantiate(m_currentWaveConfig.GetEnemyPrefab(), m_currentWaveConfig.GetWaypointList()[0].transform.position, Quaternion.identity);

            m_newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(m_currentWaveConfig);

            yield return new WaitForSeconds(m_currentWaveConfig.GetTimeBetweenSpawn());
        }
    }

}
