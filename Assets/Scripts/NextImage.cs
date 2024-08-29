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
        SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Button);

        if (i == image.Length - 1)
        {
            if (SceneManager.GetActiveScene().name == "InroScene")
            {
                SceneManager.LoadScene("Tutorial");
            }
            else
                Application.Quit();
        }
        else
        {
            image[i].SetActive(true);
            i++;
        }
    }
}
