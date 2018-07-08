using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWaypoint : MonoBehaviour {

    //Initialise Everything
    [SerializeField] public Transform[] wayPointList;
    private int currentWaypoint = 0;
    Transform targetWaypoint;

    public float spriteSpeed = 4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(currentWaypoint < this.wayPointList.Length)
        {
            if (targetWaypoint == null)
                targetWaypoint = wayPointList[currentWaypoint];
           
        }
        MoveToWayPoint();
	}

    void MoveToWayPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, spriteSpeed * Time.deltaTime);

        if(transform.position == targetWaypoint.position)
        {
            currentWaypoint++;
            if(currentWaypoint >= this.wayPointList.Length)
            {
                currentWaypoint = this.wayPointList.Length;
                targetWaypoint = wayPointList[currentWaypoint];
            }
            else
                targetWaypoint = wayPointList[currentWaypoint];
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "NavPoint 8")
        {
            Debug.Log(collision.gameObject.name);

            Destroy(gameObject);
            ParticleSystem part = GetComponent<ParticleSystem>();
            part.Play();
        }
    }
}
