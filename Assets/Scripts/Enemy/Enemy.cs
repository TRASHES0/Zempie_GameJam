using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public Sprite sprite;
    public EnemyTypes enemyType;
    public float spawnTime;
    public float spawnSpeed;
    public float CharX;
    public string state = "Miss";
    void Start(){
        _spriteRenderer.sprite = sprite;

        transform.DOMoveX(CharX - 10f, spawnSpeed).SetEase(Ease.Linear).SetLink(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PerfectRect"))
        {
            state = "Perfect";
        }else if (other.CompareTag("GreatRect"))
        {
            state = "Great";
        }else if (other.CompareTag("GoodRect"))
        {
            state = "Good";
        }
        else if (other.CompareTag("BadRect"))
        {
            state = "Bad";
        }

        other.GetComponentInParent<CharacterMovement>()._enemiesinCollider.Add(this);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PerfectRect"))
        {
            state = "Great";
        }else if (other.CompareTag("GreatRect"))
        {
            state = "Good";
        }else if (other.CompareTag("GoodRect"))
        {
            state = "Bad";
        }
        else if (other.CompareTag("BadRect"))
        {
            state = "Miss";
            Destroy(this);
        }

        other.GetComponentInParent<CharacterMovement>()._enemiesinCollider.Remove(this);
    }

}
