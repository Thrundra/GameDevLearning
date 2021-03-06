﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{

    private string towerType = "";
    // Use this for initialization
    void Start()
    {
        towerType = "unbuilt";
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnMouseDown()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);
        Debug.Log("Mouse Button Pressed");

        if (hit)
        {
            Debug.Log("I've hit something");
            if (hit.collider.gameObject.tag == "Tower")
            {
                string towerObjectName = gameObject.name;
                Debug.Log("I've hit a tower :" + towerObjectName);
            }
            else
            {
                string objectName = gameObject.name;
                Debug.Log("I've hit something else - " + objectName);
            }

        }
    }
}
