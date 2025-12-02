using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luna : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 7f;

    public KeyCode Spacebar = KeyCode.Space;
    public KeyCode L = KeyCode.A;
    public KeyCode R = KeyCode.D;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;
    private bool grounded;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        Debug.Log("Grounded: " + grounded);
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anim.SetBool("Grounded", grounded);

    }

    void Update()
    {
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }

        if (Input.GetKey(L))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            if (sr != null) sr.flipX = true;
        }

        if (Input.GetKey(R))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            if (sr != null) sr.flipX = false;
        }
        anim.SetFloat("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}

