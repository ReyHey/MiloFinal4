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
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovementState{running, jumping, falling, idle}


    // Start is called before the first frame update
    private void Start()
    {
        /// Bye Bye
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationUpdate();
          
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

    private bool IsGrounded() //checks to see if the player is standing on the ground
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
    }
    
}
