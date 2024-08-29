using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Unity.VisualScripting;
using System.Linq;


public class CharacterMovement : MonoBehaviour
{
    private bool isJumping = false;
    private bool isSliding = false;

    public float jumpPower = 20;

    private Rigidbody2D rigid;

    public Collider2D Running;
    public Collider2D Sliding;
    
    public List<Enemy> _enemiesinCollider;
    // Start is called before the first frame update
    void Start()
    {
        Running.enabled = true;
        Sliding.enabled = false;
        _enemiesinCollider = new List<Enemy>();
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

        if (Input.GetKey(KeyCode.W) && !isJumping && !isSliding)
        {
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
        
        // hit 
        if(_enemiesinCollider.Any()){
            if(Input.GetMouseButtonDown(1)) //오른쪽 마우스 버튼 입력
            {
                if(_enemiesinCollider[0].enemyType == EnemyTypes.RED)
                    Debug.Log(_enemiesinCollider[0].state);
                else
                    Debug.Log("Wrong One!");
            Destroy(_enemiesinCollider[0].gameObject);
            }
            else if(Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼 입력
            {
                if(_enemiesinCollider[0].enemyType == EnemyTypes.BLUE)
                    Debug.Log(_enemiesinCollider[0].state);
                else
                Debug.Log("Wrong One!");
                Destroy(_enemiesinCollider[0].gameObject);
            }
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
