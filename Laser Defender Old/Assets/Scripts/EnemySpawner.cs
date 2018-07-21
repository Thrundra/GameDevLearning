using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // Configuration

    [SerializeField] GameObject enemyPrefabObject;
    [SerializeField] float width = 10f;
    [SerializeField] float height = 5f;
    [SerializeField] float speed = 5f;

    private bool moveRight = false;
    private float xMax;
    private float xMin;

	// Use this for initialization
	void Start ()
    {
        float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distanceToCamera));
        Vector3 rightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distanceToCamera));

        xMax = rightBoundary.x;
        xMin = leftBoundary.x;

        foreach ( Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefabObject, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(moveRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        float rightEdgeOfFormation = transform.position.x + (0.5f * width);
        float leftEdgeOfFormation = transform.position.x - (0.5f * width);

        if(leftEdgeOfFormation < xMin)
        {
            moveRight = true; 
        }
        else if(rightEdgeOfFormation > xMax)
        {
            moveRight = false;
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }
}
