using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    // Specifiy Variables for use within this class

    // Set the speed of the character
    [SerializeField] private float speed;

    // Player Direction Refernece
    protected Vector2 direction;

    // Reference to the Animator Class
    private Animator myAnimator;

    private Rigidbody2D myRigidBody;

    public bool IsMoving
    {
        get { return direction.x != 0 || direction.y != 0; }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame.  Marked as Virtual so it can be overriden by a subclass.
    protected virtual void Update()
    {
        HandleLayers();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Move The Player
    /// </summary>
    public void Move()
    {
        // Makes sure that the player moves and normalises the speed of the character.
        myRigidBody.velocity = direction.normalized * speed;
    }

    public void HandleLayers()
    {
        // Checks if we are moving or standing still.  If move, play the move animation
        if (IsMoving)
        {
            // Animate the players movement
            ActivateLayer("Walk Layer");

            //Set the animation parameter so that he faces the correct direction.
            myAnimator.SetFloat("x", direction.x);
            myAnimator.SetFloat("y", direction.y);
        }
        else
        {
            // go back to idle animation if we are not moving.
            ActivateLayer("Idle Layer");
        }
    }

    /// <summary>
    /// Disables the layers and then sets the correct animation layer.
    /// </summary>
    /// <param name="layerName"></param>
    public void ActivateLayer(string layerName)
    {
        for(int i = 0; i < myAnimator.layerCount; i++)
        {
            myAnimator.SetLayerWeight(i, 0);
        }

        myAnimator.SetLayerWeight(myAnimator.GetLayerIndex(layerName), 1);
    }
}
