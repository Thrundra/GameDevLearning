using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectSpawnManager : MonoBehaviour
{
    [SerializeField] SceneObjectWaveConfig c_WaveConfig;

    Transform m_StartingSpawnLocation;
    float m_DelayBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBackground", 5, c_WaveConfig.GetRandomSpawnTime());
    }

    void SpawnBackground()
    {

        GameObject g_BackgroundObject = c_WaveConfig.GetBackgroundObjectPrefab();
        Transform m_BaseSpawnLocation = c_WaveConfig.GetStartingWaypoint();

        Vector3 pos = m_BaseSpawnLocation.position;
        float xPos = Random.Range(-8.5f, 9.0f);
        pos.x = xPos;
        m_BaseSpawnLocation.position = pos;

        Instantiate(g_BackgroundObject, m_BaseSpawnLocation.position, Quaternion.identity);
    }
}
