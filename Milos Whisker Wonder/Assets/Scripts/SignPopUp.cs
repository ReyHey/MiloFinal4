using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPopUp : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    //public GameObject PopUpBox;
    //public TMP_Text popUpText;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //PopUpBox.SetActive(true);
            Pop();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Close();
        }
    }

    private void Pop()
    {
        Debug.Log("Pop");
        anim.SetTrigger("Pop");
    }

    private void Close()
    {
        Debug.Log("Close");
        anim.SetTrigger("Close");
    }


    

   
}
