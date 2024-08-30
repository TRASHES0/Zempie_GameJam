using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering.Universal;
using System.Threading;
using Cysharp.Threading.Tasks.CompilerServices;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource _audioSource;
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
    void Start(){
        //TimeScaleChange(_cancellationTokenSource.Token, 시작시간, 지연시간, timeScale, 지속시간).Forget();
        //밀리세컨드 단위로 입력
        TimeScaleChange(_cancellationTokenSource.Token, 0, 2000, 1.5f, 1000).Forget();
    }

    async UniTaskVoid TimeScaleChange(CancellationToken cancellationToken, int startTime, int delayTime, float timeScale, int duration)
    {
        float t = 0f;
        float ts = Time.timeScale;
        float p = _audioSource.pitch;
        while (true)
        {
            if (t == startTime + delayTime + duration)
            {
                Time.timeScale = 1f;
                _audioSource.pitch = 1f;
                _cancellationTokenSource.Cancel();
            }
            if (cancellationToken.IsCancellationRequested) break;

            t += 1;
            if(t >= startTime && (t - startTime) <= delayTime)
            {
                Time.timeScale = Mathf.Lerp(ts, timeScale, (t - startTime) / delayTime);
                _audioSource.pitch = Mathf.Lerp(p, timeScale, (t - startTime) / delayTime);
            }
            
            await UniTask.Delay(1, true, cancellationToken: cancellationToken);
        }
    }

    private void OnDestroy()
    {
        _cancellationTokenSource.Cancel();
    }
}
