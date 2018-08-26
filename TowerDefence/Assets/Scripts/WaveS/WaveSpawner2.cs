using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner2 : MonoBehaviour {
    // Script Configuration
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public WaveContainer[] waves;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public Transform spawnLocation;

    private SpawnState state = SpawnState.COUNTING;
    private int nextWave = 0;
    private float searchCountdown = 1f;

    // Use this for initialization
    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    /*
    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                // Begin new round
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(Spawnwave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("WAve completed");
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed the test");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator Spawnwave(WaveContainer _wave)
    {
        Debug.Log("Spawning wave " + _wave.waveName);
        state = SpawnState.SPAWNING;

        // loop through wave
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        // spawn enemy
        Instantiate(_enemy, spawnLocation.position, spawnLocation.rotation);
    }
    */
}
