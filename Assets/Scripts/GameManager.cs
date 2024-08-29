using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour
{

    void Start(){

        //MkTimeSlowFast(변경시간, 지속시간, 타임스케일)
        //밀리세컨드 단위로 입력
        MkTimeSlowFast(2000, 5000, 0.75f); 

    }

    async void MkTimeSlowFast(int delayTime, int duration, float timeScale){
        await UniTask.Delay(delayTime, true);
        Time.timeScale = timeScale;
        await UniTask.Delay(duration, true);
        Time.timeScale = 1f;
    }


}
