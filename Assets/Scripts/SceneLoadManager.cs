using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void NextScene()
    {
        SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Button);

        if (SceneManager.GetActiveScene().name == "StartScene")
            SceneManager.LoadScene("IntroScene");
        else if (SceneManager.GetActiveScene().name == "Tutorial")
            SceneManager.LoadScene("Sun_GameScene");
    }
}
