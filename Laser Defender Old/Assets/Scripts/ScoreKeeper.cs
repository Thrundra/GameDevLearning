using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour {

    public static int currentScore = 0;
    private TextMeshProUGUI text;
	// Use this for initialization
	void Start () {
        text = FindObjectOfType<TextMeshProUGUI>();
        text.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = currentScore.ToString();
	}

    public void Score(int points)
    {
        currentScore += points;
    }

    public static void Reset()
    {
        currentScore = 0;
    }
}
