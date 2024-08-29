using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Unity.VisualScripting;


public class CharacterMovement : MonoBehaviour
{
    private bool isJumping = false;
    private bool isSliding = false;

    public float jumpPower = 20;

    public Collider2D Running;
    public Collider2D Sliding;

    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        Running.enabled = true;
        Sliding.enabled = false;
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Q) && !isJumping)
        {   Running.enabled = true;
            Sliding.enabled = false;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            //anim.SetBool("isjumping", true);
            isJumping = true;
        }

        if (Input.GetKey(KeyCode.W) &&!isJumping && !isSliding)
        {   
            Debug.Log("Sliding");
            Running.enabled = false;
            Sliding.enabled = true;
            isSliding = true;
        }

        if (Input.GetKeyUp(KeyCode.W) && isSliding)
        {
            Running.enabled = true;
            Sliding.enabled = false;
            isSliding = false;
        }
    }
    void FixedUpdate()
    {
        //Landing Ploatform
        if(rigid.velocity.y < 0) //내려갈떄만 스캔
        {
            Debug.Log("falling");
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 50, LayerMask.GetMask("Platform"));
            Debug.Log(rayHit.collider);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 2)
                {
                    Debug.Log("Floor");
                    isJumping = false;
                    //anim.SetBool("isjumping", false);
                }
            }
        }
    }
}
