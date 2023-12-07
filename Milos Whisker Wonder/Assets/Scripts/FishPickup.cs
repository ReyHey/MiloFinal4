using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishPickup : MonoBehaviour
{
    [SerializeField] int pointsForFishPickup = 1;

    //Cached reference
    LevelExit level;

    private void Start()
    {
        level = FindObjectOfType<LevelExit>();
        level.CountCollectedFish();
    }

    private void OnTriggerEnter2D(Collider2D collsion)
    {
        //FindObjectOfType<GameSession>().AddToScore(pointsForFishPickup);
        //FindObjectOfType<ItemCollector>().AddToScore(pointsForFishPickup);
        Destroy(gameObject);
        level.FishCollected();
    }

}