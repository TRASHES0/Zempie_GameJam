using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Unity.VisualScripting;


public class CharacterMovement : MonoBehaviour
{
    private bool isJumping = false;

    private Rigidbody2D rid;
    // Start is called before the first frame update
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
    }

    void OnJumpStart()
    {
        rid.AddForce(new Vector2(0,13),ForceMode2D.Impulse);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isJumping)
        {
            isJumping = true;
            OnJumpStart();
        }
        Debug.Log(isJumping);
    }
}
