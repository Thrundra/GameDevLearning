﻿using UnityEngine;

public class Ball : MonoBehaviour {

    // Config parameters
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    // state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    // Cache component References
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2d;

	// Use this for initialization
	void Start () {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }

	}

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            myRigidbody2d.velocity = new Vector2(velocityX, velocityY);
            hasStarted = true;
        }
    }

    void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweek = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2d.velocity += velocityTweek;
        }
    }
}
