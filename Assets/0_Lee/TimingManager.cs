using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] Collider2D[]  timingRect = null;
    Vector2[] timingBoxs = null;
    private string state;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckTiming()
    {
        for (int i = 0; i < timingRect.Length; i++)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       state = other.GetComponent<EnemyMovement>().state;
       Debug.Log(state);
    }
}
