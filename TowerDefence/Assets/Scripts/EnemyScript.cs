using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    [SerializeField] public float speed = 2.5f;

    private Transform target;
    private int wayPointIndex = 0;

	// Use this for initialization
	void Start ()
    {
        target = WayPoint.wayPoints[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
	}

    void GetNextWayPoint()
    {
        wayPointIndex++;
        target = WayPoint.wayPoints[wayPointIndex];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "DestructionCollider")
        {
            Debug.Log("creature destroyed");
            Destroy(gameObject);
        }
    }
}
