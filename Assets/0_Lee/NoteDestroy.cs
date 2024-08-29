using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NoteDestroy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        Destroy(collision.gameObject);
        
    }
}
