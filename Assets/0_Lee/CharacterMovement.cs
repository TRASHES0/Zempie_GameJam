using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using Unity.VisualScripting;
using System.Linq;
using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterMovement : MonoBehaviour
{
    private bool isJumping = false;
    private bool isSliding = false;
    private bool isHit = false;
    private bool isDead = false;

    public Text text;
    public bool Chaos = false;
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
    
   
    void FixedUpdate()
    {
        //Landing Ploatform
        if(rigid.velocity.y < 0) //내려갈떄만 스캔
        {
            //Debug.Log("falling");
            Debug.DrawRay(_groundCheck.transform.position, Vector3.down, new Color(1, 0, 0));
            RaycastHit2D rayHit = Physics2D.Raycast(_groundCheck.transform.position, Vector3.down, 11f, LayerMask.GetMask("Platform"));
            Debug.Log(rayHit.collider);
            if (rayHit.collider != null)
            {
                if (rayHit.distance < 1)
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
            DamageEffect().Forget();
            SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Hit);
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
        isDead = true;
        SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Hit);
        DeadWait().Forget();
    }

    async UniTask DeadWait()
    {
        _anim.SetTrigger("Dead");
        await UniTask.Delay(TimeSpan.FromSeconds(1f));
        SceneManager.LoadScene("DeadScene");
    } 
    void Update()
         {
             if (!Chaos) // 정상
             {
                 if (!isDead)
                 {
                     if (HP <= 0)
                         PlayerDead();
     
                     if (Input.GetKeyDown(KeyCode.Q) && !isJumping)
                     {
                         Running.enabled = true;
                         Sliding.enabled = false;
                         rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                         _anim.SetBool("IsJump", true);
                         SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Jump);
                         isJumping = true;
                     }
     
                     if (Input.GetKey(KeyCode.W) && !isJumping && !isSliding)
                     {
                         Running.enabled = false;
                         Sliding.enabled = true;
                         _anim.SetBool("IsSlide", true);
                         SoundManager.instance.SlideSound.Play();
                         isSliding = true;
                     }
     
                     if (Input.GetKeyUp(KeyCode.W) && isSliding)
                     {
                         Running.enabled = true;
                         Sliding.enabled = false;
                         _anim.SetBool("IsSlide", false);
                         SoundManager.instance.SlideSound.Stop();
                         isSliding = false;
                     }
     
                     // hit 
                     if (_enemiesinCollider.Any())
                     {
                         if (Input.GetMouseButtonDown(1)) //오른쪽 마우스 버튼 입력
                         {
                             _anim.SetTrigger("Attack2");
                             SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Attack2);
                             if (_enemiesinCollider[0].enemyType == EnemyTypes.RED)
                             {
                                 Debug.Log(_enemiesinCollider[0].state);
                                 SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.RedNode);
                            text.text = _enemiesinCollider[0].state;
                             }
                             else if (_enemiesinCollider[0].enemyType == EnemyTypes.TRASH)
                             {
                                 SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Trash);
                                 Debug.Log(_enemiesinCollider[0].state);
                            text.text = _enemiesinCollider[0].state;
                        }
                             else
                             {
                                 Debug.Log("Wrong One!");
                                 HitReaction();
                            text.text = "BAD...";
                        }

                             Destroy(_enemiesinCollider[0].gameObject);
                         }
                         else if (Input.GetMouseButtonDown(0)) //왼쪽 마우스 버튼 입력
                         {
                             _anim.SetTrigger("Attack1");
                             SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Attack1);
                             if (_enemiesinCollider[0].enemyType == EnemyTypes.BLUE)
                             {
                                 Debug.Log(_enemiesinCollider[0].state);
                                 SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.BlueNode);
                            text.text = _enemiesinCollider[0].state;
                        }
                             else if (_enemiesinCollider[0].enemyType == EnemyTypes.TRASH)
                             {
                                 SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Trash);
                                 Debug.Log(_enemiesinCollider[0].state);
                            text.text = _enemiesinCollider[0].state;
                        }
                             else
                             {
                                 Debug.Log("Wrong One!");
                            text.text = "BAD...";
                            HitReaction();
                             }
                        Destroy(_enemiesinCollider[0].gameObject);
                    }
                     }
                 }
             }
             else //반전
             {
                 Debug.Log("hi");
                 if (!isDead)
                 {
                     if (HP <= 0)
                         PlayerDead();
     
                     if (Input.GetKeyDown(KeyCode.W) && !isJumping)
                     {
                         Running.enabled = true;
                         Sliding.enabled = false;
                         rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                         _anim.SetBool("IsJump", true);
                         SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Jump);
                         isJumping = true;
                     }
     
                     if (Input.GetKey(KeyCode.Q) && !isJumping && !isSliding)
                     {
                         Running.enabled = false;
                         Sliding.enabled = true;
                         _anim.SetBool("IsSlide", true);
                         SoundManager.instance.SlideSound.Play();
                         isSliding = true;
                     }
     
                     if (Input.GetKeyUp(KeyCode.Q) && isSliding)
                     {
                         Running.enabled = true;
                         Sliding.enabled = false;
                         _anim.SetBool("IsSlide", false);
                         SoundManager.instance.SlideSound.Stop();
                         isSliding = false;
                     }
     
                     // hit 
                     if (_enemiesinCollider.Any())
                     {
                         if (Input.GetMouseButtonDown(0)) //오른쪽 마우스 버튼 입력 반전
                         {
                             _anim.SetTrigger("Attack2");
                             SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Attack2);
                             if (_enemiesinCollider[0].enemyType == EnemyTypes.RED)
                             {
                                 Debug.Log(_enemiesinCollider[0].state);
                                 SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.RedNode);
                            text.text = _enemiesinCollider[0].state;
                        }
                             else if (_enemiesinCollider[0].enemyType == EnemyTypes.TRASH)
                            {
                                SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Trash);

                                Debug.Log(_enemiesinCollider[0].state);
                                text.text = _enemiesinCollider[0].state;
                            }
                             else
                             {
                                 Debug.Log("Wrong One!");
                            text.text = "BAD...";
                            HitReaction();
                             }
     
                             Destroy(_enemiesinCollider[0].gameObject);
                         }
                         else if (Input.GetMouseButtonDown(1)) //왼쪽 마우스 버튼 입력 반전
                         {
                             _anim.SetTrigger("Attack1");
                             SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Attack1);
                             if (_enemiesinCollider[0].enemyType == EnemyTypes.BLUE)
                             {
                                 Debug.Log(_enemiesinCollider[0].state);
                                 SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.BlueNode);
                            text.text = _enemiesinCollider[0].state;
                        }
                             else if (_enemiesinCollider[0].enemyType == EnemyTypes.TRASH)
                             {
                                 SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Trash);
                                 Debug.Log(_enemiesinCollider[0].state);
                            text.text = _enemiesinCollider[0].state;
                        }
                             else
                             {
                                 Debug.Log("Wrong One!");
                                 HitReaction();
                            text.text = "BAD...";
                        }
     
                             Destroy(_enemiesinCollider[0].gameObject);
                         }
                     }
                 }
             }
     
         }

    async UniTask DamageEffect()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        GetComponent<SpriteRenderer>().color = Color.white;
        await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
    }
}
