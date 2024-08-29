using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Sprite _spriteRed;
    [SerializeField]
    private Sprite _spriteBlue;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    public EnemyTypes enemyType;
    public float spawnTime;
    public float spawnSpeed;
    public float CharX;

    void Start(){

        if(enemyType == EnemyTypes.RED) _spriteRenderer.sprite = _spriteRed;
        else if(enemyType == EnemyTypes.BLUE) _spriteRenderer.sprite = _spriteBlue;

        transform.DOMoveX(CharX, spawnSpeed).SetEase(Ease.Linear);
    }
}
