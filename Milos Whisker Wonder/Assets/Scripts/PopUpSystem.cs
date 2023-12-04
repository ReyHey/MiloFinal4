using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUpSystem : MonoBehaviour
{
    public GameObject PopUpBox;
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
        PopUpBox.SetActive(true);
        PopUpText.text = text;
        anim.SetTrigger("sign");

    }
}