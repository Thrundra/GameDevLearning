using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    // Configuration
    WaveContainer waveContainer;
    int waypointIndex = 0;
    List<Transform> waypoints;

	// Use this for initialization
	void Start () {
        waypoints = waveContainer.GetPathData();
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetWaveConfig(WaveContainer waveContainer)
    {
        this.waveContainer = waveContainer;
    }
}
