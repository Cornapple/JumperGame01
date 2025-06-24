using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour //the movement script made to move the player
{
    public GameObject player; // the in-engine object that the code with move with the below script
    public Rigidbody2D rb; // the rigidbody (2d physics) applied to the above game object

    private float horizontal; // a number value characterised by point values. in this case refering to the Horizontal axis
    private float vertical; // a number value characterised by point values. in this case refering to the Vertical axis
    public float playerMovementSpeed; // a number value characterised by point values. in this case refering to the player movement speed
    public float jumpForce = 0.5f; // a number value characterised by point values. in this case refering to the jump force of the player
    public float doubleJump = 0.3f;
    public float wallSlidingSpeed = 0.1f;

    public int jumpCount; // a whole number value pertaining to the amount of jumps the player has performed
    public int maxJumps = 2; // a whole number pertaining to the maximum amount of jumps possible for the player to perform in mid air

    public bool isGrounded; // a true or false value. in this case refering to whether the player is touching the ground or not
    public bool isJumping; // a true or false value. in this case refering to whether the player is jumping or not
    public bool isWallSliding;

    public Transform groundCheck;
    public Transform wallCheck;// empty object with collider to check if the player is touching the ground        
    public float groundCheckRadius = 0.5f; // the size of the collider used on the groundcheck
    public float wallCheckRadius = 0.5f; // the size of the collider used on the groundcheck
    public LayerMask groundLayer; // the layer mask applied to the ground to allow the groundcheck to function
    public LayerMask wallLayer;
    private void Start()
    {
        Debug.Log("Hello World");
        isGrounded = true;
        isJumping = false;
        isWallSliding = false;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        MovementSystem();
        JumpButton();
        WallSlide();
        IsWalled();
    }

    private void FixedUpdate()
    {
        CheckIfGrounded();
        //WallSlide();
    }

    #region BUTTONS 
    public void MovementSystem()
    {
        rb.velocity = new Vector2(horizontal * playerMovementSpeed, rb.velocity.y);
    }

    public void JumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded == true || jumpCount < maxJumps))
        {
            isJumping = true;
            Debug.Log("isJumping is true");
            if (jumpCount == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJump);
                Debug.Log("the double jump has been called");
            }
            jumpCount++;
        }    
    }

    public void CheckIfGrounded()
    {
        // assigns isGrounded to true or false based on proximity to groundcheck transform
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // if grounded, reset jumping
        if (isGrounded == true)
        {
            jumpCount = 0;
            isJumping = false;
            Debug.Log("isGounded is true");
        }
    }

    public bool IsWalled()
    {
        //Debug.Log("IsWalled function called");
        return Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallLayer);
    }
    private void WallSlide()
    {
        if(IsWalled() && !isGrounded == false && horizontal == 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            Debug.Log("player is wallsliding");
        }
        else
        {
            isWallSliding = false;
        }
    }
    #endregion
}