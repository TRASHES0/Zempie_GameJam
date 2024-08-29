using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class CharacterMovement : MonoBehaviour
{
    

    private float waittime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnJumpStart()
    {
        transform.DOMoveY(2.3f, waittime);
        Invoke("OnJumpEnd", waittime);
    }

    void OnJumpEnd()
    {
      
        transform.DOMoveY(-2f,waittime);
     
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnJumpStart();
        }
    }
}
