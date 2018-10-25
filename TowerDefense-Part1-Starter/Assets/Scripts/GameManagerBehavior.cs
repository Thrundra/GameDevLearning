using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour {

    public Text goldLabel;

    private int gold;
    public int Gold
    {
        get { return gold; }
        set
        {
            gold = value;
            goldLabel.GetComponent<Text>().text = "Gold: " + gold;
        }
    }
	// Use this for initialization
	void Start () {
        Gold = 1000;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
