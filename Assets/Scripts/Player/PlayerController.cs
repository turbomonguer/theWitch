using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groundCheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Call method from Physics.cs
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        FlipCharacter();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    public void MoveCharacter()
    {
        velX = Input.GetAxis("Horizontal") * speed;
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);
        if(rb.velocity.x != 0 && isGrounded)
        {
            anim.SetBool("Run", true);
        }else
        {
            anim.SetBool("Run", false);
        }
    }

    public void FlipCharacter()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
