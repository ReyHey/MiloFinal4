using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float damage = 25f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    //When the bullet hits the robot collider
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //var health = otherCollider.GetComponent<Health>();
        //var attacker = otherCollider.GetComponent<Attacker>();


        //if (attacker && health)
        //{
        //    health.DealDamage(damage);
        //    //This will destroy the bullet upon impact
        //    Destroy(gameObject);
        //}

    }
}