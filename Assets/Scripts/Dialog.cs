using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    public Image img;

    public static bool IsCheck = false; //특정 스코어나 상황을 체크하는 변수
    public static int Character; //캐릭터 이미지 체크 변수

    void Start()
    {
        text.color = Color.black;
    }   
    
    void Update()
    {
        if (IsCheck == true)
        {
            text.text = "TEST";
            talkPanel.SetActive(true);
        }
        if (Input.GetMouseButtonDown(0) && IsCheck == true)
        {
            IsCheck = false;
            talkPanel.SetActive(false);
        }
        if(Character == 0)
        {
            //img.GetComponent<Image>().sprite = Resources.Load("[이미지경로]", typeof(Sprite)) as Sprite;
        }
        else if (Character == 1)
        {
            //img.GetComponent<Image>().sprite = Resources.Load("[이미지경로]", typeof(Sprite)) as Sprite;
        }
    }
}
