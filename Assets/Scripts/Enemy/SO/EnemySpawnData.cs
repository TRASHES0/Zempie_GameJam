using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData Data", menuName = "Scriptable Object/EnemyData Data")]
public class EnemySpawnData : ScriptableObject
{
    [SerializeField][TextArea]
    private string Data;
    public string data {get{return Data;}}
}
