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

    void Start(){

        _spriteRenderer.sprite = sprite;

        transform.DOMoveX(CharX, spawnSpeed).SetEase(Ease.Linear);
    }
}
