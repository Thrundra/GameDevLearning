using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    float health = 20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
