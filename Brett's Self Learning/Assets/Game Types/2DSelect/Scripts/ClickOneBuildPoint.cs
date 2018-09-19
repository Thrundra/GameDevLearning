using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickOneBuildPoint : MonoBehaviour {

    [SerializeField] Text text;
    //public GameObject imageOnClick;
    private GameObject barrelOjbect;

    private void Awake()
    {
        barrelOjbect = Resources.Load<GameObject>("Prefabs/rpgTile203.prefab") as GameObject;
    }

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {
        DetectHit();
    }

    private void DetectHit()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            Debug.Log("Button Pressed");

            if (hit)
            {
                Debug.Log("I've hit something");
                if (hit.collider.gameObject.tag == "BuildPoint")
                {
                    GameObject selectedObject = hit.collider.gameObject;
                    GameObject barrelItemObject = GameObject.FindGameObjectWithTag("BarrelItem");
                    Vector3 barrelLocation = new Vector3(selectedObject.transform.position.x, selectedObject.transform.position.y + 0.1f, -1);

                    text.text = hit.collider.gameObject.name;
                    Debug.Log("Hit a build point");
                    Instantiate(barrelOjbect, barrelLocation, Quaternion.identity);
                }

            }
            else
            {
                text.text = " ";
            }
        }
    }
}
