using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    // Configuration Parameters

    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;

    GameStatus gameStatus;
    Ball gameBall;

	// Use this for initialization
	void Start () {
        gameStatus = FindObjectOfType<GameStatus>();
        gameBall = FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);

        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePos;
	}

    private float GetXPos()
    {
        if(gameStatus.IsAutoPlayEnabed())
        {
            return gameBall.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
