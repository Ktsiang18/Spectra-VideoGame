using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure the component this is used with has both a SpriteRenderer and an Animator
// So that the system won't fail
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]

// Because gravity in real life just doesn't work for console games we have a custom class for handling 
// physics which is entirely controlled by script as opposed to letting the engine do the work.
public class KinematicCharacterController : PhysicsObject
{
    public float jumpPower = 7;
    public float buttonReleaseJumpDamping = 0.5f;
    public float maxSpeed = 7;
    private float minSpriteFlipSpeed = 0.01f;
    private bool isFacingRight = true; // the direction the player starts facing


    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if ( Input.GetButtonDown("Jump") && isGrounded )
        {
            velocity.y = jumpPower;
        }
        else if ( Input.GetButtonUp("Jump"))
        {
            // if the player releases the jump button, decrease the jump velocity of the player by half 
            if ( velocity.y > 0 )
            {
                velocity.y = velocity.y * buttonReleaseJumpDamping;
            }
        }

        // if the input is to the left
		if (move.x < minSpriteFlipSpeed)
        {
            // if the player is facing right
            if (isFacingRight)
            {
                // tell the sprite renderer to flip along the X-axis
                spriteRenderer.flipX = true;

                // the player is no longer facing right
                isFacingRight = false;
            }
        }
		else if (move.x > minSpriteFlipSpeed)
        {
            if (!isFacingRight)
            {
                // tell the sprite renderer to stop flipping along the X-axis
                // this should have the player facing right
                //
                spriteRenderer.flipX = false;

                // the player is facing right again
                isFacingRight = true;

            }
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("xVelocity", Mathf.Abs(velocity.x) / maxSpeed);

        inputVelocity = move * maxSpeed;
    }
}

