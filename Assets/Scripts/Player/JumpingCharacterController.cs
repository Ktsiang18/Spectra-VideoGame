using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class JumpingCharacterController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public bool isFacingRight = true;
    public int jumpForce = 100;

    private bool isJumpPressed = false;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Awake is used to initialize any variables before the game starts
    // Called after all objects are initialized so you can safely communicate with other objects
    //
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called when a script is enabled. If you need to make sure something is initialized
    // put it in awake.
    //
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float vSpeed = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxisRaw("Horizontal");
        isJumpPressed = Input.GetButtonDown("Jump");

        // if the input is to the left
        if (vSpeed < 0.0)
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
        else if (vSpeed > 0.0)
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


        // we want the absolute value of the vSpeed for our animations since we want to 
        // use the 'negative' speed to just be speed in the left direction
        //

        if (vInput != 0.0f)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(vSpeed));
        }
        else
        {
            animator.SetFloat("xVelocity", 0.0f);
        }
        animator.SetFloat("xInput", vInput);



        rb.velocity = new Vector2(vSpeed * playerSpeed, rb.velocity.y);
    }

    // Called multiple times per frame depending on the frame rate
    // locked in sync with the physics engine so physics manipulation
    // should take place here - particularly with RigidBodies
    void FixedUpdate()
    {
        // if the player pressed the jump button
        // apply a rigidbody force to launch the player up in the air
        //
        if ( isJumpPressed )
        {
            // up direction with a magnitude of jumpForce
            rb.AddForce(Vector2.up * jumpForce );


            // player event is consumed
            isJumpPressed = false;
        }
    }
}

