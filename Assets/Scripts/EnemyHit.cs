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

        if (collision.CompareTag("ChaosGate"))
        {
            cm.Chaos = true;
            SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.KeyWarp);
            Invoke("ChaosTimer",10);
            
        }
    }

    private void FallPlatform()
    {
        cm.PlayerDead();
    }

    void ChaosTimer()
    {
        cm.Chaos = false;
    }

}
