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
}