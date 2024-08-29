using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextImage : MonoBehaviour
{
    public GameObject[] image;
    private int i = 0;

    // Start is called before the first frame update

    public void NextImg()
    {
        if (i == image.Length)
        {
            if (SceneManager.GetActiveScene().name == "InroScene")
            {
                SceneManager.LoadScene("Tutorial");
            }
            else
                Application.Quit();
        }
        //SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Button);
        image[i].SetActive(true);
        i++;
    }
}
