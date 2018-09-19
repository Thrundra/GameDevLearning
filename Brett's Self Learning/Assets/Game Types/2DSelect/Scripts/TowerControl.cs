using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerControl : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer towerSR;
    private Image displayImage;

    // Use this for initialization
    void Start()
    {
        towerSR = gameObject.GetComponent<SpriteRenderer>();
       /// displayImage = FindObjectOfType<Image>().
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if(towerSR.sprite.Equals(sprites[0]))
        {
            towerSR.sprite = sprites[1];
        }
        else
        {
            towerSR.sprite = sprites[0];
        }
    }

    private void OnMouseUp()
    {
        
    }

    private void OnGUI()
    {
        
    }
}