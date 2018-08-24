using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeySpawner : MonoBehaviour {

    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startingWave = 0;
    [SerializeField] bool looping = false;

	// Use this for initialization
	IEnumerator Start ()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWaveConfig)
    {
        for (int enemyCount = 0; enemyCount < currentWaveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(currentWaveConfig.GetEnemyPrefab(), currentWaveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);

            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(currentWaveConfig);

            yield return new WaitForSeconds(currentWaveConfig.GetTimeBetweenSpawn());
        }
    }
}
