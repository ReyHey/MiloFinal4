using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBox;
    private Rigidbody2D rb;
    public Animator anim;
    public TMP_Text popUpText;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sign"))
        {
            Pop("meow");
        }
    }
   */
    public void Pop(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        anim.SetTrigger("sign");

    }
}