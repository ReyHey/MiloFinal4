using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPopUp : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private Animator popUpBoxAnim;
    [SerializeField] private AudioSource signPopSound;
    //public GameObject PopUpBox;
    //public TMP_Text popUpText;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        popUpBoxAnim = GetComponentInChildren<Animator>();
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
        signPopSound.Play();
        Debug.Log("Pop");
        //anim.SetTrigger("Pop");
        popUpBoxAnim.SetTrigger("Pop");
    }

    private void Close()
    {
        Debug.Log("Close");
        //anim.SetTrigger("Close");
        popUpBoxAnim.SetTrigger("Close");
    }


    

   
}
