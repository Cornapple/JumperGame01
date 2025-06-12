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
    public float jumpForce; // a number value characterised by point values. in this case refering to the jump force of the player

    public int jumpCount; // a whole number value pertaining to the amount of jumps the player has performed
    public int maxJumps = 2; // a whole number pertaining to the maximum amount of jumps possible for the player to perform in mid air

    public bool isGrounded; // a true or false value. in this case refering to whether the player is touching the ground or not
    public bool isJumping; // a true or false value. in this case refering to whether the player is jumping or not

    public Transform groundCheck;    // empty object with collider to check if the player is touching the ground        
    public float groundCheckRadius = 0.2f; // the size of the collider used on the groundcheck
    public LayerMask groundLayer; // the layer mask applied to the ground to allow the groundcheck to function

    private void Start()
    {
        isJumping = false;
    }

    private void Update()
    {
        MovementSystem();
        JumpButton();
        //DoubleJump();
        WallSlide();
        CheckIfGrounded();

        //if (isGrounded == true)
        //{
        //    isJumping = false;
        //}
        //else
        //{
        //    isJumping = true;
        //}

        if (isGrounded == true)
        {
            jumpCount = 0;
            isJumping = false;
        }
        else
        {
            isJumping = true;
        }
    }

    #region BUTTONS 
    public void MovementSystem()
    {
        rb.velocity = new Vector2(horizontal * playerMovementSpeed, rb.velocity.y);
    }
    public void JumpButton()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            Debug.Log("the jump method has been called");
            
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.2f, rb.velocity.y * 0.5f);
            Debug.Log("the double jump has been called");
            return; 
        }
    
    }

    public void CheckIfGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    //public void DoubleJump()
    //{



    //}

    public void WallSlide()
    {

    }

    #endregion



}