using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour {

	// Script Configuration
	public enum SpawnState { SPAWNING, WAITING, COUNTING};
	
	public Wave[] waves;
	public float timeBetweenWaves = 5f;
	public float waveCountdown;
	public Transform spawnLocation;

	private SpawnState state = SpawnState.COUNTING;
	private int nextWave = 0;
	private float searchCountdown = 1f;

	// Use this for initialization
	void Start ()
	{
		waveCountdown = timeBetweenWaves;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(state ==  SpawnState.WAITING)
		{
			if(!EnemyIsAlive())
			{
				// Begin new round
				WaveCompleted();
			}
			else
			{
				return;
			}
		}

		if(waveCountdown <= 0)
		{
			if(state != SpawnState.SPAWNING)
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

	IEnumerator Spawnwave(Wave _wave)
	{
		Debug.Log("Spawning wave " + _wave.waveName);
		state = SpawnState.SPAWNING;

		// loop through wave
		for(int i = 0; i< _wave.count; i++)
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
        float _xDeviation = UnityEngine.Random.Range(-0.6f, 0.6f);
        float _yDeviation = UnityEngine.Random.Range(-0.6f, 0.6f);
        Transform temp;
        Vector3 tempVector = new Vector3(spawnLocation.position.x + _xDeviation, spawnLocation.position.y + _yDeviation, 0);
       // temp = tempVector;

		Instantiate(_enemy, tempVector, spawnLocation.rotation);
	}

	[System.Serializable]
	public class Wave
	{

		// Config info
		public string waveName;
		public Transform enemy;
		public int count;
		public float rate;
	}
}
