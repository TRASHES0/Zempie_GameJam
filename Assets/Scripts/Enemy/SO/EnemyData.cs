using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyTypes{ RED, BLUE }
public class EnemyData : MonoBehaviour
{   
    [System.Serializable]
    public class Enemy{
        public EnemyTypes enemyType;
        public float spawnTime;
        public string Pos;
        public float spawnSpeed;
    }

    public List<Enemy> enemies;
}
