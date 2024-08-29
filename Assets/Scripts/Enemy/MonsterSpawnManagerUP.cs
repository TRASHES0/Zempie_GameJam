using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class MonsterSpawnManagerUP : MonoBehaviour
{
    [SerializeField]
    private Transform _MonsterObj_Red;
    [SerializeField]
    private Transform _MonsterObj_Blue;

    private enum Types{
        Red,
        Blue
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //SpawnMonster(개수, 스폰 지연 시간, 타입)
    async void SpawnMonster(int spawn_num, int delay_time, Types type){
        if(type == Types.Red)
            for(int i = 0; i < spawn_num; ++i){
                Instantiate(_MonsterObj_Red, transform.position, transform.rotation).GetComponent<EnemyMovement>()._targetpos = new Vector2(0f, 3f);
                await UniTask.Delay(delay_time);
            }
        else if(type == Types.Blue)
            for(int i = 0; i < spawn_num; ++i){
                Instantiate(_MonsterObj_Blue, transform.position, transform.rotation).GetComponent<EnemyMovement>()._targetpos = new Vector2(0f, 3f);
                await UniTask.Delay(delay_time);
            }
    }

        void Update(){
        if(Input.GetKeyDown(KeyCode.Q))
            SpawnMonster(1, 0, Types.Red);
        if(Input.GetKeyDown(KeyCode.E))
            SpawnMonster(1, 0, Types.Blue);
    }
}
