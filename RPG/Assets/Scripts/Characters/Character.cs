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
    private Animator animator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame.  Marked as Virtual so it can be overriden by a subclass.
    protected virtual void Update()
    {
        Move();
    }

    /// <summary>
    /// Move The Player
    /// </summary>
    public void Move()
    {
        // Makes sure that the player moves.
        transform.Translate(direction * speed * Time.deltaTime);

        // Checks if we are moving or standing still.  If move, play the move animation
        if(direction.x !=0 || direction.y !=0)
        {
            // Animate the players movement
            AnimateMovement(direction);
        }
        else
        {
            // go back to idle animation if we are not moving.
            animator.SetLayerWeight(1, 0);
        }
    }

    /// <summary>
    /// Makes the player animate in the correct direction
    /// </summary>
    /// <param name="direction"></param>
    public void AnimateMovement(Vector2 direction)
    {
        animator.SetLayerWeight(1, 1);

        //Set the animation parameter so that he faces the correct direction.
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }
}
