using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHit : MonoBehaviour
{

    [SerializeField]
    private Animator p_anim;
    [SerializeField]
    private Animator a_anim;
    [SerializeField]
    private CharacterMovement cm;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.CompareTag("Obstacle"))
        {
            p_anim.SetTrigger("Hit");
            a_anim.SetTrigger("Hit");

            cm.HitReaction();
        }
        else if(collision.CompareTag("FallObstacle"))
        {
            Debug.Log("Hi");
            p_anim.SetTrigger("Hit");
            a_anim.SetTrigger("Hit");
            collision.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            FallPlatform();
        }
        else if(collision.CompareTag("Note"))
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
