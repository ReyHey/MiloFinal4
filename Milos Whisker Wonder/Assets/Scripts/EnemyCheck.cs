using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] float bounce = 1200f;
    //animator = GetComponent<EnemyPatrol>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyStomp>())
        {
            Debug.Log("BOOM!");

            // Get the player's Rigidbody2D component
            Rigidbody2D playerRigidbody = playerRb.GetComponent<Rigidbody2D>();

            // Check if the playerRigidbody is not null
            if (playerRigidbody != null)
            {
                // Apply an upward force to make the player fly
                playerRigidbody.AddForce(Vector2.up * bounce); // You can adjust the force as needed
            }

            // Destroy the robot parent GameObject
            Destroy(transform.parent.gameObject);
        }
    }
}
