﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Background Object")]
public class SceneObjectWaveConfig : ScriptableObject
{
    [SerializeField] GameObject[] a_ListOfBackgroundObjectPrefab;
    [SerializeField] GameObject g_BaseWaypointPath;
    [SerializeField] float m_BackgroundOjectBaseMove = 0.01f;
    [SerializeField] float m_WhenToCheckForObjectStart = 1f;
    [SerializeField] float m_startTimerForSpawn = 1f;
    [SerializeField] float m_endTimeForSpawn = 10f;

    public GameObject GetBackgroundObjectPrefab()
    {
        int m_RandomNumber = UnityEngine.Random.Range(0, a_ListOfBackgroundObjectPrefab.Length);
        return a_ListOfBackgroundObjectPrefab[m_RandomNumber];
    }

    private int GetRandomNumber()
    {
        return Random.Range(0, a_ListOfBackgroundObjectPrefab.Length);
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

    public float GetSpawnTimeCheck()
    {
        return m_WhenToCheckForObjectStart;
    }

    public float GetRandomSpawnTime()
    {
        return UnityEngine.Random.Range(m_startTimerForSpawn, m_endTimeForSpawn);
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
