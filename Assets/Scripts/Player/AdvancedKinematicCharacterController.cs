using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Because gravity in real life just doesn't work for console games we have a custom class for handling 
// physics which is entirely controlled by script as opposed to letting the engine do the work.
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class AdvancedKinematicCharacterController : PhysicsObject
{
    public float jumpPower = 7;
    public float buttonReleaseJumpDamping = 0.5f;
    public float maxSpeed = 7;
    private float minSpriteFlipSpeed = 0.0f;
    private bool isFacingRight = true; // the direction the player starts facing


    private bool isFalling;
    private bool isJumping;
    private bool isShooting;
	private bool slide;

    public float fallMultiplier = 2.5f;


    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();


        // if we are falling, speed up the fall
        if (velocity.y < 0)
        {
            //rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

            animator.SetBool("isFalling", true);
        }
        else if ( velocity.y >= 0 )
        {
           animator.SetBool("isFalling", false);
        }


	/*
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Run") && velocity.x == 0)
		{
			//rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

			animator.SetBool("slide", true);
    }
    */

	}
    
    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
         //   velocity.y = jumpPower;
           // animator.SetTrigger("isJumping");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            // if the player releases the jump button, decrease the jump velocity of the player by half 
            if (velocity.y > 0)
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
        animator.SetFloat("xVelocity", Mathf.Abs(move.x) / maxSpeed);

        inputVelocity = move * maxSpeed;


    }

    public void shoot()
    {
        
    }
}

