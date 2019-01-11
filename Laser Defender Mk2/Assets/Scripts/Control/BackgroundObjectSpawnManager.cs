using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectSpawnManager : MonoBehaviour
{
    [SerializeField] SceneObjectWaveConfig c_WaveConfig;

    GameObject g_BackgroundObject;
    Transform m_BaseSpawnLocation;
    Transform m_StartingSpawnLocation;
    float m_DelayBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBackground", c_WaveConfig.GetRandomSpawnTime(), c_WaveConfig.GetRandomSpawnTime());
    }

    void SpawnBackground()
    {
        m_BaseSpawnLocation = c_WaveConfig.GetStartingWaypoint();
        float xPos = Random.Range(-3f, 3f);

        m_StartingSpawnLocation.position = new Vector2(xPos, m_BaseSpawnLocation.position.y);

        g_BackgroundObject = c_WaveConfig.GetBackgroundObjectPrefab();
        Instantiate(g_BackgroundObject, m_StartingSpawnLocation.position, Quaternion.identity);
    }
}
