using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    private GameObject Note = null;
    private string state;
    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
        Note = other.GameObject();
       //Debug.Log(state);
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
        Note = null;
        //Debug.Log(state);
    }

    void Update()
    {
        if (Note == null)
        {
            
        }
        else if (Note.CompareTag("Note") && Input.GetKeyDown(KeyCode.Space))
        {
            state = Note.GetComponent<EnemyMovement>().state;
            Destroy(Note);
            Note = null;
            Debug.Log("Score :" + state);
        }
    }
}
