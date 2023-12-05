using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] float bounce = 300f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Collision with tag: " + collision.tag);
        if (collision.GetComponent<PlayerMovement>())
        {
            Debug.Log("FLY MILO!");
            //playerRb.velocity = new Vector2(playerRb.velocity.x, bounce);
            playerRb.AddForce(Vector2.up * bounce);
        }
        
    }
}
