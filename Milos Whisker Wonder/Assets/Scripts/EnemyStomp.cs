using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomp : MonoBehaviour
{
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weak Point"))
        {
            Debug.Log("BOOM!");
            Destroy(collision.gameObject);
            
        }
    }
}
