using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private float timer;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-1, 0).normalized * force;
        rb.gravityScale = 0f;
        
        /*player = GameObject.FindGameObjectWithTag("Player!");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        */
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //if bullet has been out for 10 seconds, destroy bullet
        if(timer>5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player!"))
        {
            Destroy(collision.gameObject);
        }
    }
}
