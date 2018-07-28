using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    float health = 20f;
    [SerializeField] float laserSpeed = 10f;
    [SerializeField] GameObject projectile;
    [SerializeField] float shotsPerSecond = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float probability = Time.deltaTime * shotsPerSecond;

        if (Random.value < probability)
        {
            FireLaser();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerLaser missile = collision.gameObject.GetComponent<PlayerLaser>();

        if(missile)
        {
            health -= missile.GetDamage();
            missile.Hit();
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("I've been hit... going... down....");

        }
    }

    private void FireLaser()
    {
        Vector3 laserStart = transform.position + new Vector3(0, -0.5f, 0);
        GameObject laserBeam = Instantiate(projectile, laserStart, Quaternion.identity) as GameObject;
        laserBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -laserSpeed, 0);
    }
}
