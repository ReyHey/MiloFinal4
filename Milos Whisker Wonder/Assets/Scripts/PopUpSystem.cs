using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Sign"))
        {
            Pop();
        }
    }

    private void Pop()
    {
        Debug.LogWarning("sign");
    }
}
/*
     private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<RigidBody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision))
    {
        if (collision.gameObject.CompareTag("Sign"))
            Pop();

    public void Pop(string text)
    {
      
        popUpBox.SetActive(true);
        popUpText.text = text;
        anim.SetTrigger("pop");
        
Debug.Log("sign");
    }
 */