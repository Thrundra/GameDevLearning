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
    [SerializeField] GameObject m_PlayerPrimarylaser;
    [SerializeField] float m_PlayerProjectileSpeed = 10f;
    [SerializeField] float m_PlayerProjectileFiringSpeed = 0.2f;

    float xMin, xMax, yMin, yMax;
    private int m_PlayerDamageLevel;
    private List<GameObject> l_ListOfParticleEffects;

    private bool b_Level2damage, b_Level3Damage;
    Coroutine c_PlayerFiringCoroutine;
    Transform m_PlayerDamageVisual;

    private Animator a_PlayerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        SetupMoveBoundaries();
        SetDamageOverlayPosition();
        b_Level2damage = false;
        b_Level3Damage = false;
        a_PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FirePrimaryWeapon();
        RenderPlayerDamage();
    }

    private void SetDamageOverlayPosition()
    {
        m_PlayerDamageVisual = transform.Find("PlayerDamageOverlay");
        m_PlayerDamageVisual.localPosition = new Vector3(0.01f, 0.01f, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObjectDamageDealer damageDealer = collision.gameObject.GetComponent<GameObjectDamageDealer>();
        if(!damageDealer)
        {
            return;
        }

        ProcessHit(damageDealer);
    }

    #region Player Movment
    private void SetupMoveBoundaries()
    {
        //Set the limits of how fare the player can move based upon the camera. Save the x & y axis to the Class variables.
        Camera _gameCamera = Camera.main;
        xMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + m_Padding;
        xMax = _gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - m_Padding;

        yMin = _gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + m_Padding;
        yMax = _gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - m_Padding - 0.5f;
    }

    private void MovePlayer()
    {
        //getting the input from the unity controller and the key press, move the player in that direction.
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * m_PlayerMoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * m_PlayerMoveSpeed;

        // Set the new positions from the previous ones.
        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        // Using a Vector2, set the current position.
        transform.position = new Vector2(newXPos, newYPos);
    }
    #endregion

    #region Player Health
    public int GetHealth()
    {
        return m_PlayerHealth;
    }

    public void RenderPlayerDamage()
    {
        if(m_PlayerHealth > 400)
        {
            m_PlayerDamageVisual.GetComponent<SpriteRenderer>().enabled = false;
        }

        else if(m_PlayerHealth < 401 && m_PlayerHealth > 300)
        {
            SetSpriteOnDamage(0);
        }
        else if(m_PlayerHealth < 301 && m_PlayerHealth > 150)
        {
            SetSpriteOnDamage(1);
            SetSmokeEffectOnPlayerShip(1);
        }
        else if(m_PlayerHealth < 151 && m_PlayerHealth >0)
        {
            SetSpriteOnDamage(2);
            SetSmokeEffectOnPlayerShip(2);
        }
    }

    private void SetSpriteOnDamage(int value)
    {
        Sprite tempSprite = m_PlayerDamageVisual.GetComponent<PlayerDamageLevel>().GetSprite(value);
        m_PlayerDamageVisual.GetComponent<SpriteRenderer>().enabled = true;
        m_PlayerDamageVisual.GetComponent<SpriteRenderer>().sprite = tempSprite;
    }

    private void SetSmokeEffectOnPlayerShip(int value)
    {
        if (value == 1)
        {
            if (!b_Level2damage)
            {
                GameObject tempGameObject = m_PlayerDamageVisual.GetComponent<PlayerDamageLevel>().GetSmokeParticleEffect(transform.position, value);
                GameObject o_FirstSmoke = Instantiate(tempGameObject, tempGameObject.transform.position, tempGameObject.transform.rotation) as GameObject;
                o_FirstSmoke.transform.SetParent(this.transform.GetChild(0));
                b_Level2damage = true;
            }
            else
            {

            }
        }
        else if (value == 2)
        {
            if (!b_Level3Damage)
            {
                GameObject tempGameObject = m_PlayerDamageVisual.GetComponent<PlayerDamageLevel>().GetSmokeParticleEffect(transform.position, value);
                GameObject o_SecondSmoke = Instantiate(tempGameObject, tempGameObject.transform.position, tempGameObject.transform.rotation) as GameObject;
                o_SecondSmoke.transform.SetParent(this.transform.GetChild(0));
                b_Level3Damage = true;
            }
        }
    }

    private void OnPlayerDeath()
    {
        a_PlayerAnimator.SetTrigger("PlayerDeath");
        a_PlayerAnimator.Play("PlayerExplosion");
        Destroy(gameObject.transform.GetChild(0).gameObject);
        Destroy(gameObject, 1.8f);
        FindObjectOfType<LevelController>().DelayLoadScene("PlayerDeath");
    }

    private void ProcessHit(GameObjectDamageDealer damageDealer)
    {
        m_PlayerHealth -= damageDealer.GetDamage();
        damageDealer.DestoryOnHit();

        if (m_PlayerHealth <= 0)
            OnPlayerDeath();
    }
    #endregion

    #region Shooting Mechanics

    private void FirePrimaryWeapon()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            c_PlayerFiringCoroutine = StartCoroutine(FirePrimaryWeaponContinuously());
        }

        if(Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(c_PlayerFiringCoroutine);
        }
    }

    IEnumerator FirePrimaryWeaponContinuously()
    {
        while(true)
        {
            GameObject g_PlayerLaser = Instantiate(m_PlayerPrimarylaser, transform.position, Quaternion.identity) as GameObject;
            g_PlayerLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, m_PlayerProjectileSpeed);
            yield return new WaitForSeconds(m_PlayerProjectileFiringSpeed);
        }
    }
    #endregion
}
