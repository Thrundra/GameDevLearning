using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    // Configuration

    [SerializeField] GameObject enemyPrefabObject;
    [SerializeField] float width = 10f;
    [SerializeField] float height = 5f;
    [SerializeField] float speed = 5f;
    [SerializeField] float spawnDelay = 0.5f;
    [SerializeField] int score = 10;


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

        SpawnUntilFull();
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

        if(AllMembersDead())
        {
            Debug.Log("All EMPTY");
            SpawnUntilFull();
        }
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
    }

    bool AllMembersDead()
    {
        foreach(Transform childPosGameObject in transform)
        {
            if(childPosGameObject.childCount > 0)
            {
                return false;
            }

        }
        return true;
    }

    Transform NextFreePostion()
    {
        foreach(Transform childPostion in transform)
        {
            if (childPostion.childCount == 0)
                return childPostion;
        }
        return null;
    }

    private void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefabObject, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    private void SpawnUntilFull()
    {
        Transform nextFreePosition = NextFreePostion();
        if (nextFreePosition)
        {
            GameObject enemy = Instantiate(enemyPrefabObject, nextFreePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = nextFreePosition;
        }

        if (NextFreePostion())
        {
            Invoke("SpawnUntilFull", spawnDelay);
        }
    }
}
