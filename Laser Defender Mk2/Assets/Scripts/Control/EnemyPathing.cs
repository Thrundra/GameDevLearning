using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    EnemyWaveConfig m_WaveConfig;
    int m_WaypointIndex = 0;
    List<Transform> m_WaypointList;
    // Start is called before the first frame update
    void Start()
    {
        m_WaypointList = m_WaveConfig.GetWaypointList();
        transform.position = m_WaypointList[m_WaypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        if(m_WaypointIndex <= m_WaypointList.Count -1)
        {
            var m_TargetPosition = m_WaypointList[m_WaypointIndex].transform.position;
            var movementThisFrame = m_WaveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, m_TargetPosition, movementThisFrame);

            if(transform.position == m_TargetPosition)
            {
                m_WaypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWaveConfig(EnemyWaveConfig waveConfig)
    {
        this.m_WaveConfig = waveConfig;
    }
}
