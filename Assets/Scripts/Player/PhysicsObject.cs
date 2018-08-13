using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

    public float gravityModifier = 1.0f;
    public float minimumMoveDistance = 0.001f;
    public float minimumGroundNormal = 0.65f;
    public float skinPadding = 0.01f;

    protected Vector2 velocity;
    protected Vector2 inputVelocity; // velocity produced from some input device
    protected Rigidbody2D rb;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);
    protected bool isGrounded = false;
    protected Vector2 groundNormal;


    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();

        Debug.Log("In enable");

        Debug.Log(rb);
    }

    void Awake()
    {
     //   rb = GetComponent<Rigidbody2D>();

    //    Debug.Log("In Awake");

    //    Debug.Log(rb);


        contactFilter.useTriggers = false;

        // set the layers that we want to check for collisions so that we are not
        // checking for collsions on every layer
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        inputVelocity = Vector2.zero;
        ComputeVelocity();
	}

    protected virtual void ComputeVelocity()
    {

    }

    protected virtual void FixedUpdate()
    {
        // add in gravity the object's velocity
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

        // add in the x component of the input controller
        velocity.x = inputVelocity.x;

        isGrounded = false;



        // determine where the object will be located in the next frame
        // based on the gravity and the gravity modifier. Note that we are
        // using the Physics2D gravity which is set in Unity itself to be
        // compatible with the Unity IDE
        //
        Vector2 deltaPosition = velocity * Time.deltaTime;

        // generate a vector along the line which will be based on the ground normal
        // this would specifically be useful for slopes
        //
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 moveX = moveAlongGround * deltaPosition.x;

        Movement(moveX, false);

        Vector2 moveY = Vector2.up * deltaPosition.y;

        Movement(moveY, true);
    }

    void Movement( Vector2 move, bool hasYMovement )
    {
        // get the distance that we would be moving in this frame
        float moveDistance = move.magnitude;

        // make sure the object would be moving far enough this frame
        // before checking for any collisions so that we're not checking
        // for collisions when the object is at rest
        if ( moveDistance > minimumMoveDistance )
        {
            int collisionCount = rb.Cast(move, contactFilter, hitBuffer, moveDistance + skinPadding);

            // clear the previous results
            hitBufferList.Clear();

            // build the list of things that we would hit
            //
            for (int i=0; i< collisionCount; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;

                // make sure that the player will be able to 
                // be considered on the ground if the angle of the surface
                // the player is on is less than the value of the minimumGroundNormal
                if ( currentNormal.y > minimumGroundNormal )
                {
                    isGrounded = true;

                    if ( hasYMovement )
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;

                    }

                    // if we are going to hit something, we want to cancel out the
                    // velocity in that direction, but preserve velocity in other directions
                    //
                    float projection = Vector2.Dot(velocity, currentNormal);
                    if ( projection < 0 )
                    {
                        velocity = velocity - projection * currentNormal;
                    }

                    float modifiedDistance = hitBufferList[i].distance - skinPadding;
                    moveDistance = modifiedDistance < moveDistance ? modifiedDistance : moveDistance;
                }
            }
        }


        //Debug.Log("RigidBody " + rb);
        // set the position of the object's rigidbody by adding the movement vector
        // passed into the method to the existing rigidbody positon
        // This will manually move the object.
        rb.position = rb.position + move.normalized * moveDistance;
    }
}
