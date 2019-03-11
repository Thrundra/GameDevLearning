using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private float characterSpeed = 4.0f;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D mouseClickLocation = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.zero);

            targetPosition = mouseClickLocation.transform.position;
            // targetLocation.position = targetPosition;
            Debug.Log("Mouse button pressed " + targetPosition.x + " and y: " + targetPosition.y);
        }

        if((Vector3)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, characterSpeed * Time.deltaTime);
            Debug.Log("object: " + transform.position.x + " and y: " + transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        
    }
}
