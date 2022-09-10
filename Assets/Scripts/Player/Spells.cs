using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{
    public float jumpHeight;
    
    Rigidbody2D rb;
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
        MeleeAtack();
        RangeAtack();
    }

    private void FixedUpdate()
    {
        Jump();
    }

    public void Jump()
    {
        // Jump
        if(Input.GetButton("Jump") && Grounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        // Ascending
        else if (rb.velocity.y > 0)
        {
            anim.SetBool("Jump", true);
        }
        // Falling
        else if (rb.velocity.y < 0)
        {
            anim.SetBool("Fall", true);
        }
        else if (Grounded())
        {
            anim.SetBool("Jump", false);
            anim.SetBool("Fall", false);
        }
    }

    public void MeleeAtack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("MeleeGround");
        }
    }

    public void RangeAtack()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("RangeGround");
        }
    }

    public bool Grounded()
    { // Check if player is grounded, taking the var from PlayerController.cs
        return GameObject.Find("Player").GetComponent<PlayerController>().isGrounded;
    }
}
