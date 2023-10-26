using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Game : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
        Debug.Log("Quitting");

    }
	public void ChangeScene()
	{
		SceneManager.LoadScene("SampleScene");
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
