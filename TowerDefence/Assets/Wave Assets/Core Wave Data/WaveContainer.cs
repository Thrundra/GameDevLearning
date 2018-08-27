using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Descriptor")]
public class WaveContainer : ScriptableObject
{
    [SerializeField] List<WaveEnemyAmount> e_EnemyWaveData;
    [SerializeField] GameObject path;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.3f;

    public GameObject GetEnemyPrefab()
    {

    }
}
