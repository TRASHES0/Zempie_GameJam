using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform Center = null;
    [SerializeField] RectTransform[]  timingRect = null;
    Vector2[] timingBoxs = null;
    
    // Start is called before the first frame update
    void Start()
    {
        timingBoxs = new Vector2[timingRect.Length];
        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(Center.localPosition.x - timingRect[i].rect.width/2,
                Center.localPosition.x + timingRect[i].rect.width/2);
        }
    }

    public void CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_notePosX = boxNoteList[i].transform.localPosition.x;
            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (t_notePosX >= timingBoxs[x].x && t_notePosX <= timingBoxs[x].y)
                {
                    Debug.Log("hit" + x);
                    return;
                }
            }
        }
        
        Debug.Log("miss");
        return;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
