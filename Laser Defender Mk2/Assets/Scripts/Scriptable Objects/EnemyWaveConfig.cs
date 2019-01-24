using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class EnemyWaveConfig : ScriptableObject
{
    // Create the fields needed.
    [SerializeField] GameObject p_EnemyPrefab;
    [SerializeField] GameObject w_WaypointPrefab;
    [SerializeField] float m_TimeBetweenSpawns = 0.5f;
    [SerializeField] float m_RandomFactor = 0.3f;
    [SerializeField] int m_NoOfEnemies = 5;
    [SerializeField] float m_EnemyMoveSpeed = 2f;

    public GameObject GetEnemyPrefab() { return p_EnemyPrefab; }

    public GameObject GetWapointPathPrefab() { return w_WaypointPrefab; }

    public float GetTimeBetweenSpawn() { return m_TimeBetweenSpawns; }

    public float GetSpawnRandomFactor() { return m_RandomFactor; }

    public int GetNumberOfEnemies() { return m_NoOfEnemies; }

    public float GetEnemyMoveSpeed() { return m_EnemyMoveSpeed; }

    public List<Transform> GetWaypointList()
    {
        var w_WaypointList = new List<Transform>();
        foreach(Transform child in w_WaypointPrefab.transform)
        {
            w_WaypointList.Add(child);
        }

        return w_WaypointList;
    }
}