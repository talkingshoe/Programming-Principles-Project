using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//taken from DaveGameDev on YT

public class PlayerMovement : MonoBehaviour
{
    
    //inspector header
    [Header("Movement")]

    //pc move speed
    public float moveSpeed;

    //custom value
    public float groundDrag;

    //inspector header
    [Header("Ground Check")]

    //half pc heigt plus a bit extra
    public float playerHeight;

    //the mask for the ray to check for
    public LayerMask whatIsGround;

    //true if grounded else not
    bool grounded;

    //pc transform
    public Transform orientation;

    //store keyboard inputs
    float horizontalInput;
    float verticalInput;

    //pc direction
    Vector3 moveDirection;

    //rigidbody ref
    Rigidbody rb;

    private void Start()
    {
        //assign rigidbody to var
        rb = GetComponent<Rigidbody>();
        //freeze pc rotation otherwise player will fall over
        rb.freezeRotation = true;
    }

    //checks for input every frame
    private void Update()
    {
        //ground check, shoot a ray from this position, in this direction, this long, until you find this
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        MyInput();

        //handle drag
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;

        SpeedControl();
    }

    //applies changes based on input every frame
    private void FixedUpdate()
    {
        MovePlayer();
    }

    //assign keyboard inputs to var
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        //calculate movement direction, this way you'll always walk in the direction that you're looking
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        //this allows the actual MOVEMENT part of the movement
        //(in the direction that's calculated about (i.e the direction you're facing) * moveSpeed * number that makes movement faster, continuous force)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    //keeps movement speed constant at the rate set in movespeed
    private void SpeedControl()
    {
        //the flat velocity (a time period in which velocity is constant (i.e not changing in value)) of your rigidbody
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        //limit velocity if needed
        if (flatVel.magnitude > moveSpeed)
        {
            //set a var named limitedvel to the normalized flatvel value times movespeed
            //normalization ensures consistancy by converting values to a common, shared scale
            //so instead of flatvel e.g. 11.32654, normalized it becomes 0.7 or something; so if movespeed is 7 then instead of 79,28578 the value returns 4.9
            //other normalized values will also use 0.7 instead of 11.32654, maintaining consistancy 
            //I think
            //as per video comment: you calculate what your max velocity would be...
            Vector3 limitedVel = flatVel.normalized * moveSpeed;

            //apply limitedvel to rigidbody if condition is met
            //as per video comment: ...and then apply it
            rb.linearVelocity = new Vector3(limitedVel.x, 0, limitedVel.z);
        }
    }

}
