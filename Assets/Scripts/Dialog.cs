using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    public Image img;

    public static bool IsCheck = false; //Ư�� ���ھ ��Ȳ�� üũ�ϴ� ����
    public static int Character; //ĳ���� �̹��� üũ ����

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
            //img.GetComponent<Image>().sprite = Resources.Load("[�̹������]", typeof(Sprite)) as Sprite;
        }
        else if (Character == 1)
        {
            //img.GetComponent<Image>().sprite = Resources.Load("[�̹������]", typeof(Sprite)) as Sprite;
        }
    }
}
