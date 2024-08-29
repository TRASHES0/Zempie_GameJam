using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hit : MonoBehaviour
{

    [SerializeField]
    private Animator p_anim;
    [SerializeField]
    private Animator a_anim;
    [SerializeField]
    private CharacterMovement cm;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            p_anim.SetTrigger("Hit");
            a_anim.SetTrigger("Hit");

            cm.HitReaction();
        }
    }

    private void FallPlatform()
    {
        cm.PlayerDead();
    }

}
