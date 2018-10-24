using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypointWalk : MonoBehaviour {

    [SerializeField] GameObject waypoints;

    private Transform[] waypointLocations;

	// Use this for initialization
	void Start () {
		foreach(GameObject wpObject in waypoints)
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
