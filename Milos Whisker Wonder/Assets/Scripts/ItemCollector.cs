using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fish = 0;
    [SerializeField] private Text fishtext;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Fish"))
        {
            Destroy(collision.gameObject);
            fish++;
            fishtext.text = "Fish: " + fish;
        }
    }   


}
