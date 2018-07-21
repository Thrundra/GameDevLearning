using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Configuration

    [SerializeField] float speed = 15f;

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
}
