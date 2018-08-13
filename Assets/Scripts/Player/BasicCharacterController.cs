using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    public float playerSpeed = 5.0f;
    public bool isFacingRight = true;

    private Rigidbody2D rb;
    private Animator animator;

    // Awake is used to initialize any variables before the game starts
    // Called after all objects are initialized so you can safely communicate with other objects
    //
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called when a script is enabled. If you need to make sure something is initialized
    // put it in awake.
    //
    void Start()
    {

    }

	// Update is called once per frame
	void Update () {

        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("vSpeed", move);

        rb.velocity = new Vector2(move * playerSpeed, rb.velocity.y);
	}

    // Called multiple times per frame depending on the frame rate
    // locked in sync with the physics engine so physics manipulation
    // should take place here - particularly with RigidBodies
    void FixedUpdate()
    {

    }
}
