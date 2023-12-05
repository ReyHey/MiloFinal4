using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    public float bounce;
    public Rigidbody rb2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weak Point"))
        {
            Destroy(collision.gameObject);
            rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
        }
        
    }
}
