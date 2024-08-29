using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashObj : MonoBehaviour
{
    [SerializeField] float fallSec = 0.5f, destroySec = 2f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "cone" || collision.gameObject.name == "sign" || collision.gameObject.name == "truck")
        {
            //오브젝트 충돌시 이벤트
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //맨홀 추락 이벤트
    {
        if (collision.gameObject.name.Equals("Character"))
        {
            Invoke("FallPlatform", fallSec);
            Destroy(gameObject, destroySec);
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }

}
