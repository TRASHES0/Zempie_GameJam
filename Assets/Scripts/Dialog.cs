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

    void Update()
    {
        if (IsCheck)
        {
            text.text = "TEST";
            IsCheck = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            talkPanel.SetActive(false);
        }
        if(Character == 0)
        {
        //[���ӿ�����Ʈ].GetComponent<Image>().sprite = Resources.Load("[�̹������]", typeof(Sprite)) as Sprite;
        }
        else if (Character == 1)
        {
        //[���ӿ�����Ʈ].GetComponent<Image>().sprite = Resources.Load("[�̹������]", typeof(Sprite)) as Sprite;
        }

    }
}
