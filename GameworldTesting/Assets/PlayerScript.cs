using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Vector2 targetPosition;
    Rigidbody2D playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * 2.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DeepForest"))
        {
            Debug.Log("I've hit a deep forest tile");
            targetPosition = transform.position;
        }



    }
}
