using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float runSpeed = 7f;
    private SpriteRenderer sprite;
    private float dirX = 0f;
    private Rigidbody2D rb;
    private Animator anim;

    private enum MovementState{running, jumping, falling, idle}


    // Start is called before the first frame update
    void Start()
    {
        /// Bye Bye
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
  
    }

    private void Run()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);

        UpdateAnimationUpdate();
        
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        // running right
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        //running left
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        // standing still
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("movementState", (int)state);
    }

    
}
