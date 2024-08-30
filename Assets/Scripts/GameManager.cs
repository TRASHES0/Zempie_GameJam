using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering.Universal;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private AudioSource _audioSource;
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();


    public float t;
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
        //TimeScaleChange(_cancellationTokenSource.Token, 시작시간, 지연시간, timeScale, 지속시간).Forget();
        //밀리세컨드 단위로 입력

        if(arg0.name == "Sun_GameScene")
            TimeScaleChange(_cancellationTokenSource.Token, 10 , 20, 0.5f, 5).Forget();
        else if (arg0.name == "Rain_GameScene")
            TimeScaleChange(_cancellationTokenSource.Token, 0, 20, 2f, 10).Forget();
    }

    async UniTaskVoid TimeScaleChange(CancellationToken cancellationToken, int startTime, int delayTime, float timeScale, int duration)
    {
        t = 0f;
        float ts = Time.timeScale;
        float p = _audioSource.pitch;
        while (true)
        {
            if (t > startTime + delayTime + duration)
            {
                Time.timeScale = 1f;
                _audioSource.pitch = 1f;
                _cancellationTokenSource.Cancel();
            }
            if (cancellationToken.IsCancellationRequested) break;

            t += Time.deltaTime;
            if(t >= startTime && (t - startTime) <= delayTime)
            {
                Time.timeScale = Mathf.Lerp(ts, timeScale, (t - startTime) / delayTime);
                _audioSource.pitch = Mathf.Lerp(p, timeScale, (t - startTime) / delayTime);
            }
            
            await UniTask.Delay(0, cancellationToken: cancellationToken);
        }
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
    }
}
