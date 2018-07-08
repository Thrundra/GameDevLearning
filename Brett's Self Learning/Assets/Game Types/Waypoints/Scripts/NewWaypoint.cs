using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaypoint : MonoBehaviour {

    // Initialise everything
    [SerializeField] public Transform[] wayPointList;

    public int currentWaypoint = 0;
    Transform targetWayPoint;

    public float spriteSpeed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWaypoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWaypoint];
           
            MoveToWayPoint();
        }
        else if (currentWaypoint == this.wayPointList.Length)
        {
            currentWaypoint = 0;
            targetWayPoint = wayPointList[currentWaypoint];
            MoveToWayPoint();
        }

	}

    void MoveToWayPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, spriteSpeed * Time.deltaTime);

        if(transform.position == targetWayPoint.position)
        {
            currentWaypoint++;
            if (currentWaypoint >= this.wayPointList.Length)
            {
                currentWaypoint = 0;
                targetWayPoint = wayPointList[currentWaypoint];
            }
            else if (currentWaypoint < this.wayPointList.Length)
            {

                targetWayPoint = wayPointList[currentWaypoint];
            }
        }
    }
}
