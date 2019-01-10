using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Config Parameters
    [Header("Player")]
    [SerializeField] float m_PlayerMoveSpeed = 10f;
    [SerializeField] float m_Padding = 0.5f;
    [SerializeField] int m_PlayerHealth = 500;
    [SerializeField] int m_PlayerShieldHealth = 0;

    [Header("Player Weapons")]
    [SerializeField] GameObject m_Playerlaser;
    [SerializeField] float m_PlayerProjectileSpeed = 10f;
    [SerializeField] float m_PlayerProjectileFiringSpeed = 0.1f;

    float xMin, xMax, yMin, yMax;
    private int m_PlayerDamageLevel;

    Coroutine c_PlayerFiringCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    #region Player Movment
    private void SetupMoveBoundaries()
    {
        Camera _gameCamera = Camera.main;
        xMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + m_Padding;
        xMax = _gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - m_Padding;

        yMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + m_Padding;
        yMax = _gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - m_Padding - 0.5f;
    }

    private void MovePlayer()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * m_PlayerMoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * m_PlayerMoveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);

        
    }
    #endregion

    #region Player Health
    public int GetHealth()
    {
        return m_PlayerHealth;
    }
    #endregion
}
