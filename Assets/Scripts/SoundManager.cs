using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource bgSound;
    public AudioSource effectSound;
    public AudioSource SlideSound;
    public AudioClip[] bgList;
    public AudioClip[] effectList;
    public enum EffectType
    {
        Button,
        Attack1,
        Attack2,
        Bad,
        BlueNode,
        RedNode,
        EnemyBlueNode,
        EnemyRedNode,
        Trash,
        Hit,
        Jump,
        Slide,
        Dead,
        KeyWarp
    };

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "StartScene")
        {
            BgSoundPlay(bgList[0]);
        }
        else if (arg0.name == "Sun_GameScene")
        {
            //BgSoundPlay(bgList[1]);
        }
        else if (arg0.name == "Rain_GameScene")
        {
            //BgSoundPlay(bgList[1]);
        }
        else if (arg0.name == "DeadScene")
        {
            //BgSoundPlay(bgList[3]);
            //SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.Die);
        }
        else if (arg0.name == "EndScene")
        {
            //BgSoundPlay(bgList[4]);
        }
    }

    public void BgSoundPlay(AudioClip clip)
    {
        bgSound.clip = clip;
        bgSound.loop = true;
        bgSound.volume = 0.35f;
        bgSound.Play();
    }

    public void EffectSoundPlay(int type)
    {
        effectSound.volume = 0.7f;
        effectSound.PlayOneShot(effectList[type]);
    }

}
