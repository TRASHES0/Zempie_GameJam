using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
public class MonsterSpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform _MonsterObj;
    // Start is called before the first frame update
    void Start()
    {
        SpawnMonster();
    }

    async void SpawnMonster(){
        for(int i = 0; i < 5; ++i){
            Instantiate(_MonsterObj, transform.position, transform.rotation);
            await UniTask.Delay(500);
        }
    }
}
