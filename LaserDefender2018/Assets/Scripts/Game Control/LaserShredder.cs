using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShredder : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("I've been hit by a " + collider.gameObject.name);
        Destroy(collider.gameObject);
    }
}
