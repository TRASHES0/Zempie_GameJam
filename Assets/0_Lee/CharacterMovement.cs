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
    
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Q) && !isJumping)
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            //anim.SetBool("isjumping", true);
            isJumping = true;
        }
    }
    void FixedUpdate()
    {
        //Landing Ploatform
        if(rigid.velocity.y < 0) //내려갈떄만 스캔
        {
            Debug.Log("falling");
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 15, LayerMask.GetMask("Platform"));
            Debug.Log(rayHit.collider);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1.5)
                {
                    isJumping = false;
                    //anim.SetBool("isjumping", false);
                }
            }
        }
    }
}
