using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void QuitGame()
    {
        UnityEngine.Application.Quit();
        Debug.Log("Quitting");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
