using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    TextMeshProUGUI scoreText;
    GameControl gameControl;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameControl = FindObjectOfType<GameControl>();
    }

    private void Update()
    {
        scoreText.text = gameControl.GetScore().ToString();
    }
}
