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

    private bool isGrounded;
    private bool isJumping;

    [SerializeField] private Transform groundCheck;



    private void Start()
    {
        isGrounded = false;
        isJumping = false;
    }

    private void Update()
    {
        MovementSystem();
        JumpButton();
        DoubleJumpButton();
        WallSlide();
    
    }
    #region BUTTONS 
    public void MovementSystem()
    {
        rb.velocity = new Vector2(horizontal * playerMovementSpeed, rb.velocity.y);

    }
    public void JumpButton()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown("Jump") && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyUp("Jump") && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x * 0.2f, rb.velocity.y * 0.5f);
        }
    }

    public void DoubleJumpButton()
    {
        if (isGrounded == false && rb.velocity.y > 0)
        {

        }
    }

    public void WallSlide()
    {

    }

    #endregion



}