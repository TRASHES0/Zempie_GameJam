using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class EnemyMovement : MonoBehaviour
{
    public Vector2 _targetpos;
    private Sequence _sequence;
   
    public string state = "Miss";
    private enum Types{
        Red,
        Blue
    }

    // Start is called before the first frame update
    void Start()
    {
        
        _sequence = DOTween.Sequence();

        //DOTween.Init(bool recycle, bool useSafeMode, LogBehaviour logBehaviour, SetCapacity setCapacity)
        DOTween.Init(true, true, LogBehaviour.Verbose).SetCapacity(200, 50);

        // .Append 트윈 뒤에 추가
        // .Join 앞에 추가된 트윈과 동시 시작
        // .Insert 특정 시간에 시작
        // .Prepend 맨 처음에 추가

        _sequence.Append(transform.DOMoveY(_targetpos.y, 2f).SetEase(Ease.OutQuad))
        .Join(transform.DOMoveX(_targetpos.x, 2f).SetEase(Ease.InQuad));

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

    // Update is called once per frame
    void Update()
    {
       
    }
}
