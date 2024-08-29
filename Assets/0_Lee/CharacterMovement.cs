using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Unity.VisualScripting;


public class CharacterMovement : MonoBehaviour
{
    private bool isJumping = false;

    public float jumpPower = 20;

    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
/*
    void OnJumpStart()
    {
        rigid.AddForce(new Vector2(0,13),ForceMode2D.Impulse);
        
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
    }*/
    
    
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            //anim.SetBool("isjumping", true);
        }
    }
    void FixedUpdate()
    {
        //Landing Ploatform
        if(rigid.velocity.y < 0) //내려갈떄만 스캔
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 0.5f)
                {
                    //anim.SetBool("isjumping", false);
                }
            }
        }
    }
}
