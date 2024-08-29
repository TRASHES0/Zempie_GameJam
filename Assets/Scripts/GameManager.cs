using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Light2D _light; 
    

    void Start(){

        //MkTimeSlowFast(변경시간, 지속시간, 타임스케일)
        //밀리세컨드 단위로 입력
        MkTimeSlowFast(2000, 5000, 0.75f); 


    }

    async void MkTimeSlowFast(int delayTime, int duration, float timeScale){
        await UniTask.WaitUntil(DelayCompleted);
        Time.timeScale = timeScale;
        _light.intensity = 2f;
        _light.color = Color.yellow;
        await UniTask.Delay(duration, true);
        Time.timeScale = 1f;
        _light.intensity = 1f;
    }

    bool DelayCompleted(){
        
        return true;
    }


}
