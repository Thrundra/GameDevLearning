﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Configuration Parameters
    [Header("Player")]
    [SerializeField] float playerMoveSpeed = 10f;
    [SerializeField] float padding = 1f;
    [SerializeField] int health = 500;

    [Header("Player Laser")]
    [SerializeField] GameObject playerLaser;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringSpeed = 0.1f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    Coroutine firingCoroutine;

    [Header("Audio")]
    [SerializeField] AudioClip playerDeathClip;
    [SerializeField] AudioClip playerLaserClip;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.7f;
    [SerializeField] [Range(0, 1)] float laserSoundVolume = 0.7f;

    // Use this for initialization
    void Start () {
        SetupMoveBoundaries();
	}

    // Update is called once per frame
    void Update () {
        MovePlayer();
        FirePlayerLaser();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        
        ProcessHit(damageDealer);
        
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();

        if(health <= 0)
        {
            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        FindObjectOfType<LevelManager>().LoadGameOver();
        AudioSource.PlayClipAtPoint(playerDeathClip, Camera.main.transform.position, deathSoundVolume);
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return health;
    }

    private void MovePlayer()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * playerMoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * playerMoveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void FirePlayerLaser()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject laser = Instantiate(playerLaser, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(playerLaserClip, Camera.main.transform.position, laserSoundVolume);
            yield return new WaitForSeconds(projectileFiringSpeed);
                 
        }
    }
}
