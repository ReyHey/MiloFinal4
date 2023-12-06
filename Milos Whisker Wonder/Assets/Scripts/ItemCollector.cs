using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fish = 0;
    [SerializeField] private Text fishtext;

    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            fish++;
            fishtext.text = "Fish: " + fish;

            
        }
    }
}
