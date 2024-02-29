using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Animator animator;
    private bool isGrounded = true; 
    private bool jumpRequest;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        
        // Request a jump if the jump button is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        // Perform the jump if requested and the player is grounded
        if (jumpRequest && isGrounded)
        {
            Jump();
        }
    }
    
    void Jump()
    {
        // Apply jump force
        transform.position += Vector3.up * jumpForce * Time.fixedDeltaTime;
        animator.SetBool("isJumping", true);
        
        // Reset the flags
        isGrounded = false;
        jumpRequest = false;
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Apply movement
        transform.position += new Vector3(moveHorizontal * moveSpeed * Time.deltaTime, 0f, 0f);

        if (moveHorizontal != 0)
        {
            // Update the animator with movement info
            animator.SetBool("isWalking", true);
            
            // Flip the character model if moving left or right
            transform.localScale = new Vector3(Mathf.Sign(moveHorizontal) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            // Stop walking if there's no horizontal input
            animator.SetBool("isWalking", false);
        }
    }

    // This function will be called when the player touches the ground
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with the ground
        // if (collision.gameObject.CompareTag("Ground"))
        // {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        //}
    }
    
}
    