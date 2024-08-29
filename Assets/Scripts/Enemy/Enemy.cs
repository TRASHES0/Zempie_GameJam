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

        transform.DOMoveX(CharX, spawnSpeed).SetEase(Ease.Linear);
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
        }
        
    }

}
