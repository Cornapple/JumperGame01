using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D rb;

    private float horizontal;
    private float vertical;
    public float playerMovementSpeed;
    public float jumpForce;

    public int jumpCount;
    public int maxJumps = 2;

    public bool isGrounded;
    public bool isJumping;

    public Transform groundCheck;           
    public float groundCheckRadius = 0.2f; 
    public LayerMask groundLayer;

    private void Start()
    {
        isGrounded = true;
        isJumping = false;
    }

    private void Update()
    {
        MovementSystem();
        JumpButton();
        //DoubleJump();
        WallSlide();

        if (isGrounded == true)
        {
            isJumping = false;
        }
        else if (isGrounded  == false)
        {
            isJumping = true;
        }

        //if(isGrounded == true)
        //{
        //    jumpCount = 0;
        //}
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

    //public void DoubleJump()
    //{



    //}

    public void WallSlide()
    {

    }

    #endregion



}