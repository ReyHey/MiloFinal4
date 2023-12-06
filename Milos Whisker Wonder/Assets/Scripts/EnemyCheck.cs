using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] float bounce = 1200f;
    [SerializeField] public AudioSource robotDeathEffect;
    private Renderer robotRenderer;
    private Rigidbody2D robotRigidbody;
    private BoxCollider2D robotCollider;
    //animator = GetComponent<EnemyPatrol>();

    private void Start()
    {
        robotRenderer = transform.parent.GetComponent<Renderer>();
        robotRigidbody = transform.parent.GetComponent<Rigidbody2D>();
        robotCollider = transform.parent.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyStomp>())
        {

            Debug.Log("BOOM!");
            robotDeathEffect.Play();

            robotRenderer.enabled = false;
            robotRigidbody.simulated = false;
            robotCollider.enabled = false;

            // Get the player's Rigidbody2D component
            Rigidbody2D playerRigidbody = playerRb.GetComponent<Rigidbody2D>();

            // Check if the playerRigidbody is not null
            if (playerRigidbody != null)
            {
                // Apply an upward force to make the player fly
                playerRigidbody.AddForce(Vector2.up * bounce); // You can adjust the force as needed
            }

            // Destroy the robot parent GameObject
            //Destroy(transform.parent.gameObject);

            StartCoroutine(DestroyAfterDelay(robotDeathEffect.clip.length));
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(transform.parent.gameObject);
    }
}