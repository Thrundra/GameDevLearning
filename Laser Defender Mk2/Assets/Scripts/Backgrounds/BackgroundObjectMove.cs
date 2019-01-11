using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundObjectMove : MonoBehaviour
{
    SceneObjectWaveConfig c_WaveConfig;
    int m_waypointIndex = 0;
    List<Transform> waypoints;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = c_WaveConfig.GetWaypoints();
        transform.position = waypoints[m_waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBackgroundObject();
    }

    public void SetWaveConfig(SceneObjectWaveConfig config)
    {
        this.c_WaveConfig = config;
    }

    private void MoveBackgroundObject()
    {
        if(m_waypointIndex <= waypoints.Count -1)
        {
            var targetPosition = waypoints[m_waypointIndex].transform.position;
            var m_MoveThisFrame = c_WaveConfig.GetBackgroundObjectSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, m_MoveThisFrame);

            if(transform.position == targetPosition)
            {
                m_waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
