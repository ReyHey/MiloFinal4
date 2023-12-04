using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    private SpriteRenderer sprite;
    private float dirX = 0f;

    // Component References
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    //private CapsuleCollider2D coll;

    private Vector2 colliderSize;
    private float slopeDownAngle;
    private Vector2 slopNormalPerp;
    private bool isOnSlope;
    private float slopeDownAngleOld;
    private bool isGrounded;
    private Vector2 newVelocity;
    private float slopeSideAngle;

    private Animator anim;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float runSpeed = 7f;
    [SerializeField] float slopeCheckDistance;
	[SerializeField] private float rotationSpeed = 10f;



	private enum MovementState{running, jumping, falling, idle}


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        //coll = GetComponent<CapsuleCollider2D>();
        colliderSize = coll.size;
        anim = GetComponent<Animator>();
    }

	// Update is called once per frame
	private void Update()
	{
		Jump();
		UpdateAnimationUpdate();
		SlopeCheck();

		float slopeRotation = isOnSlope ? -slopeSideAngle : 0f;
		float smoothRotation = Mathf.LerpAngle(transform.rotation.eulerAngles.z, slopeRotation, Time.deltaTime * 10f);
		transform.rotation = Quaternion.Euler(0, 0, smoothRotation);

		if (isGrounded && !isOnSlope)
		{
			newVelocity.Set(runSpeed * dirX, 0.0f);
			rb.velocity = newVelocity;
		}
		else if (isGrounded && isOnSlope)
		{
			float slopeVelocityX = Mathf.Cos(slopeDownAngle * Mathf.Deg2Rad) * runSpeed * dirX;
			float slopeVelocityY = Mathf.Sin(slopeDownAngle * Mathf.Deg2Rad) * runSpeed * dirX;

			Vector2 slopeMovement = new Vector2(slopeVelocityX, slopeVelocityY);
			RaycastHit2D hit = Physics2D.Raycast(rb.position, slopeMovement.normalized, slopeMovement.magnitude * Time.deltaTime, jumpableGround);

			if (hit.collider == null)
			{
				// No obstacle in the way, move the character
				newVelocity.Set(slopeVelocityX, slopeVelocityY);
				rb.velocity = newVelocity;
			}
		}
		else if (!isGrounded)
		{
			newVelocity.Set(runSpeed * dirX, rb.velocity.y);
			rb.velocity = newVelocity;
		}
	}

	private void SlopeCheck()
	{
		Vector2 checkPos = transform.position - new Vector3(0.0f, colliderSize.y / 2);

		SlopCheckVertical(checkPos);
		SlopCheckHorizontal(checkPos);

		// Calculate the target rotation based on the slope normal
		Quaternion targetRotation = isOnSlope ? Quaternion.FromToRotation(Vector3.up, slopNormalPerp) : Quaternion.identity;

		// Smoothly interpolate between the current rotation and the target rotation
		transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}



	private void SlopCheckHorizontal(Vector2 checkPos)
    {
        RaycastHit2D slopeHitFront = Physics2D.Raycast(checkPos, transform.right, slopeCheckDistance, jumpableGround);
        RaycastHit2D slopeHitBack = Physics2D.Raycast(checkPos, -transform.right, slopeCheckDistance, jumpableGround);

        if (slopeHitFront)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitFront.normal, Vector2.up);
        }
        else if (slopeHitBack)
        {
            isOnSlope = true;
            slopeSideAngle = Vector2.Angle(slopeHitBack.normal, Vector2.up);
        }

        else
        {
            slopeSideAngle = 0.0f;
            isOnSlope = false;
        }
    }

    private void SlopCheckVertical(Vector2 checkPos)
    {
        RaycastHit2D hit = Physics2D.Raycast(checkPos, Vector2.down, slopeCheckDistance, jumpableGround);

        if (hit)
        {
            slopNormalPerp = Vector2.Perpendicular(hit.normal).normalized;
            slopeDownAngle = Vector2.Angle(hit.normal, Vector2.up);

            if (slopeDownAngle != slopeDownAngleOld)
            {
                isOnSlope = true;
            }

            slopeDownAngleOld = slopeDownAngle;

            Debug.DrawRay(hit.point, slopNormalPerp, Color.red);
            Debug.DrawRay(hit.point, hit.normal, Color.green);
        }
    }

    private void Jump()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * runSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
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

        if(rb.velocity.y > 0.1f && !IsGrounded())
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -0.1f && !IsGrounded())
        {
            state = MovementState.falling;
        }

        anim.SetInteger("movementState", (int)state);
    }


  


    //checks to see if the player is standing on the ground
    private bool IsGrounded() 
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
    }
    
}
