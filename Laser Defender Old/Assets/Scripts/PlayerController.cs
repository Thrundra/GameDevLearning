using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Configuration

    [SerializeField] float speed = 15f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    float fireRate = 0.2f;
    
    float padding = 1f;
    float xMin = -5f;
    float xMax = 5f;

    private void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
        Vector3 rightMostPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xMin = leftMostPosition.x + padding;
        xMax = rightMostPosition.x - padding;
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Fire", 0.000001f, fireRate);

        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Fire");
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Restricting player to the game space.
        float newX = Mathf.Clamp(transform.position.x, xMin, xMax);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}

    void Fire()
    {
        GameObject laserBeam = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
        laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
    }
}
