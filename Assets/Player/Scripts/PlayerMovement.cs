using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float acceleration;
    [SerializeField] private Rigidbody body;
    [SerializeField] private float jumpDistance;
    [SerializeField] private float jumpDuration;

    private int jumpCounter;

    public Transform Camera;


    private float jumpForce;


    public bool isGrounded;


    /*
     The player can do double jump
     */


    private void Start()
    {
        jumpCounter = 0;

        isGrounded = true;

        jumpForce = (Physics.gravity.y * jumpDuration);
        jumpForce *= jumpForce * body.mass;
        jumpForce /= 2 * jumpDistance;
    }

    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        body.velocity = Vector3.Dot(body.velocity, Camera.up)*Camera.up+ (speed + acceleration*Time.deltaTime)*(-Camera.forward * horizontal + Camera.right * vertical);

        
        
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            jump();

    }


    private void jump()
    {
        if (jumpCounter <= 1)
        {
            body.AddForce(new Vector3(body.velocity.x, jumpForce, body.velocity.z));
            jumpCounter++;
        }
        else
            isGrounded = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        jumpCounter = 0;

    }
}
