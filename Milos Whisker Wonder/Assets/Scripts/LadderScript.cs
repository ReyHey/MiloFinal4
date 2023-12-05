using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{

    private bool isLadder;
    private float speed = 8f;
    private float vertical;
    private bool isClimbing;
    [SerializeField] private Rigidbody2D rb; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        
        if(isLadder && Mathf.abs(vertical) < 0f) 
        {
        isClimbing = true;
        }
    }

    private void FixedUpdate() 
    {
    if(isClimbing) 
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Ladder"))
        { 
        isLadder = true;
        }
    }

   private void OnTriggerExit2D(Collider2D collission)
    {
		if (collission.CompareTag("Ladder"))
		{ 
        isLadder = false;
        isClimbing = false;
        }
	}
}
