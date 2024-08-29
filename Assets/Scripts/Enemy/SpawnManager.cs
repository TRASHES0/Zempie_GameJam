using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private MonsterSpawnManagerUP _SpawnerUP;
    [SerializeField]
    private MonsterSpawnManagerDown _SpawnerDOWN;
    public float startTime;
    public float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time - startTime;
    }
}
