using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Stat playerHealth;
    [SerializeField] private Stat playerMana;

   // [SerializeField] private float healthValue;

    [SerializeField] private float initHealth;
    [SerializeField] private float initMana;
    // Start is called before the first frame update
    protected override void Start()
    {
        playerHealth.Initialise(initHealth, initHealth);
        playerMana.Initialise(initMana, initMana);

        base.Start();
    }

    // Update is called once per frame - We are overriding the character.cs update function
    protected override void Update()
    {

        // Executes the GetUserInput function
        GetUserInput();
        base.Update();
    }

    /// <summary>
    /// Listen's to the players input.
    /// </summary>
    private void GetUserInput()
    {
        direction = Vector2.zero;

        if(Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            playerHealth.MyCurrentValue -= 10;
            playerMana.MyCurrentValue -= 10;
        }

        if(Input.GetKeyDown(KeyCode.O))
        {
            playerHealth.MyCurrentValue += 10;
            playerMana.MyCurrentValue += 10;
        }
    }
}
