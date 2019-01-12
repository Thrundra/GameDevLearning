using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Background Object")]
public class SceneObjectWaveConfig : ScriptableObject
{
    [SerializeField] GameObject[] a_ListOfBackgroundObjectPrefab;
    [SerializeField] GameObject g_BaseWaypointPath;
    [SerializeField] float m_BackgroundOjectBaseMove = 0.01f;

    public GameObject GetBackgroundObjectPrefab()
    {
        int m_RandomNumber = UnityEngine.Random.Range(0, a_ListOfBackgroundObjectPrefab.Length);
        return a_ListOfBackgroundObjectPrefab[m_RandomNumber];
    }

    public GameObject GetBackgroundObjectPathPrefab()
    {
        return g_BaseWaypointPath;
    }

    public Transform GetStartingWaypoint()
    {
        return g_BaseWaypointPath.transform.GetChild(0);
    }

    public Transform GetEndingWaypoint()
    {
        return g_BaseWaypointPath.transform.GetChild(1);
    }

    public float GetRandomSpawnTime()
    {
        return UnityEngine.Random.Range(5, 10);
    }

    public float GetBackgroundObjectSpeed()
    {
        return m_BackgroundOjectBaseMove;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        foreach(Transform child in g_BaseWaypointPath.transform)
        {
            waveWaypoints.Add(child);
        }
        int amount = waveWaypoints.Count;
        Debug.Log("No of waypoints = " + amount);
        return waveWaypoints;
    }
}
