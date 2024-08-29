using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Unity.VisualScripting;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    private bool isJumping = false;
    private bool isSliding = false;
    private bool isHit = false;
    private bool isDead = false;
    private Animator _anim;

    public float jumpPower = 20;
    private int HP = 3;
    public GameObject[] HP_Image;

    private Rigidbody2D rigid;

    public Collider2D Running;
    public Collider2D Sliding;
    [SerializeField]
    private BoxCollider2D _groundCheck;
    
    public List<Enemy> _enemiesinCollider;

    // Start is called before the first frame update
    void Start()
    {
        Running.enabled = true;
        Sliding.enabled = false;
        _enemiesinCollider = new List<Enemy>();
        TryGetComponent(out rigid);
        TryGetComponent(out _anim);
        //TryGetComponent(out _groundCheck);
    }
    
    void Update()
    {
        
        if(!isDead)
        {
            if (HP <= 0)
                PlayerDead();

            if (Input.GetKeyDown(KeyCode.Q) && !isJumping)
            {
                Running.enabled = true;
                Sliding.enabled = false;
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                _anim.SetBool("IsJump", true);
                isJumping = true;
            }

            if (Input.GetKey(KeyCode.W) && !isJumping && !isSliding)
            {
                Running.enabled = false;
                Sliding.enabled = true;
                _anim.SetBool("IsSlide", true);
                isSliding = true;
            }

            if (Input.GetKeyUp(KeyCode.W) && isSliding)
            {
                Running.enabled = true;
                Sliding.enabled = false;
                _anim.SetBool("IsSlide", false);
                isSliding = false;
            }

            if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼 입력
            {
                _anim.SetTrigger("Attack1");
            }
            else if (Input.GetMouseButtonDown(1)) //오른쪽 마우스 버튼 입력
            {
                _anim.SetTrigger("Attack2");
            }

            // hit 
            if (_enemiesinCollider.Any())
            {
                if (Input.GetMouseButtonDown(1)) //오른쪽 마우스 버튼 입력
                {
                    if (_enemiesinCollider[0].enemyType == EnemyTypes.RED)
                        Debug.Log(_enemiesinCollider[0].state);
                    else if (_enemiesinCollider[0].enemyType == EnemyTypes.TRASH)
                        Debug.Log(_enemiesinCollider[0].state);
                    else
                    {
                        Debug.Log("Wrong One!");
                        HitReaction();
                    }

                    Destroy(_enemiesinCollider[0].gameObject);
                }
                else if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼 입력
                {
                    if (_enemiesinCollider[0].enemyType == EnemyTypes.BLUE)
                        Debug.Log(_enemiesinCollider[0].state);
                    else if (_enemiesinCollider[0].enemyType == EnemyTypes.TRASH)
                        Debug.Log(_enemiesinCollider[0].state);
                    else
                    {
                        Debug.Log("Wrong One!");
                        HitReaction();
                    }
                        


                    Destroy(_enemiesinCollider[0].gameObject);

                }
            }
        }
        
    }
    void FixedUpdate()
    {
        //Landing Ploatform
        if(rigid.velocity.y < 0) //내려갈떄만 스캔
        {
            //Debug.Log("falling");
            Debug.DrawRay(_groundCheck.transform.position, Vector3.down, new Color(0, 1, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(_groundCheck.transform.position, Vector3.down, 1f, LayerMask.GetMask("Platform"));
            Debug.Log(rayHit.collider);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1.5)
                {
                    isJumping = false;
                    _anim.SetBool("IsJump", false);
                }
            }
        }
    }

    public void HitReaction()
    {
        if(!isHit && !isDead)
        {
            HitWait().Forget();
            HP_Image[HP - 1].SetActive(false);
            HP--;
        }
    }

    async UniTask HitWait()
    {
        isHit = true;
        await UniTask.Delay(TimeSpan.FromSeconds(2f));
        isHit = false;
    }

    public void PlayerDead()
    {
        _anim.SetTrigger("Dead");
    }

    async UniTask DeadWait()
    {
        isDead = true;
        await UniTask.Delay(TimeSpan.FromSeconds(2f));
    }
}
