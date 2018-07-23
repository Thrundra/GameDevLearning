using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour {

    public float damage = 10f;

    public float GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
