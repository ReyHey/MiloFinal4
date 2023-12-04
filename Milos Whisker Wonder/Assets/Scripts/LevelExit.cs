using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    //Seralized for debugging
    // You need 3 fish for the portal to open
    [SerializeField] int collectableFish;

    [SerializeField] float levelLoadDelay = 1f;

    Animator myAnimator;

    private void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = false;
        myAnimator = GetComponent<Animator>();
    }

    public void CountCollectedFish()
    {
        collectableFish++;
    }

    public void FishCollected()
    {
        collectableFish--;
        Debug.Log("Fish collected");
        if (collectableFish <= 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
            Debug.Log("Portal opening...");
            myAnimator.SetBool("isOpen", true);
        }
    }


    /*private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(LoadNextLevel());
    }*/

    /*IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }*/
}