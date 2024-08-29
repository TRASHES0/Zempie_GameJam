using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataProcessing : MonoBehaviour
{
    [SerializeField]
    private SpawnManager _spawnManager;
    public EnemySpawnData enemySpawnData;
    private EnemyData _enemyData;
    void Awake(){
        GameObject EnemySpawnDataGO = new GameObject("Spawn DB");
        EnemySpawnDataGO.transform.position = transform.position;
        EnemySpawnDataGO.transform.parent = transform;

        _enemyData = EnemySpawnDataGO.AddComponent<EnemyData>();
        _enemyData.enemies = new List<EnemyData.Enemy>();

        string[] row = enemySpawnData.data.Split('\n');
        foreach(string s in row){
            EnemyData.Enemy tmpEnemy = new EnemyData.Enemy();
            string[] splitData = s.Split(',');
            if(splitData[0] == "Blue") tmpEnemy.enemyType = EnemyTypes.BLUE;
            else tmpEnemy.enemyType = EnemyTypes.RED;
            tmpEnemy.spawnTime = float.Parse(splitData[1]);
            tmpEnemy.Pos = splitData[2];
            tmpEnemy.spawnSpeed = float.Parse(splitData[3]);

            _enemyData.enemies.Add(tmpEnemy);
        }

        _spawnManager.enemyData = _enemyData;
    }

}
