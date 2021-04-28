using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Transform celingCheck;
    public Transform groundCheck;
    public LayerMask GroundObijects;
    public float CheckRadius;
    public int maxjumpCount;

    private Rigidbody2D rb;

    private bool FacingRight = true;
    private float moveDirection;
    private bool isJumping = false;
    private bool IsGrounded;
    private int JumpCount;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        JumpCount = maxjumpCount;
    }

    // Update is called once per frame
    void Update()
    {
        //get inputs
        ProcessInput();
        
        //Animate
        Animate();
    }
    //Better for Phy
    private void FixedUpdate()
    {
        //Check Ground
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, GroundObijects);
        if (IsGrounded)
        {
            JumpCount = maxjumpCount;
        }
        //move
        Move();
    }

    private void Animate()
    {
        if (moveDirection > 0 && !FacingRight)
        {
            FlipPlayer();
        }
        else if (moveDirection < 0 && FacingRight)
        {
            FlipPlayer();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            JumpCount--;
        }
        isJumping = false;
    }

    private void ProcessInput()
    {
        moveDirection = UnityEngine.Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && JumpCount > 0)
        { 

            isJumping = true;
        }
    }

    private void FlipPlayer()
    {
        FacingRight = !FacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
