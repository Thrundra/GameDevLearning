using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    // COnfig data
    [SerializeField] float screenWidthInUnits = 18f;
    [SerializeField] float screenHeightInUnitys = 10f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 17f;
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 9f;

    float mousePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mouseXPos = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        float mouseYPos = Input.mousePosition.y / Screen.height * screenHeightInUnitys;

        Vector2 shipPosition = new Vector2(transform.position.x, transform.position.y);
        shipPosition.x = Mathf.Clamp(mouseXPos, minX, maxX);
        shipPosition.y = Mathf.Clamp(mouseYPos, minY, maxY);

        transform.position = shipPosition;
	}
}
