using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private Transform _enemyObj;
    [SerializeField]
    private Transform _enemyT;
    [SerializeField]
    private Transform _spawnerUP;
    [SerializeField]
    private Transform _spawnerDOWN;
    [SerializeField]
    private Transform _char;
    [SerializeField]
    private Sprite[] _sprites;
    private Enemy _enemy;
    public EnemyData enemyData;

    // Start is called before the first frame update
    void Start()
    {
        foreach(EnemyData.Enemy enemy in enemyData.enemies)
            SpawnEnemy(enemy.Pos, enemy.enemyType, enemy.spawnTime, enemy.spawnSpeed);
    }

    async void SpawnEnemy(string Pos, EnemyTypes enemyType, float spawnTime, float speed){
        await UniTask.Delay(Mathf.FloorToInt(spawnTime * 1000f));

        if(Pos == "UP"){
            _enemy = Instantiate(_enemyObj, _spawnerUP.position, _spawnerUP.rotation).GetComponent<Enemy>();
            Destroy(Instantiate(_enemyT, _spawnerUP.position, _spawnerUP.rotation).gameObject, 1f);
        }
        else if(Pos == "DOWN"){
            _enemy = Instantiate(_enemyObj, _spawnerDOWN.position, _spawnerDOWN.rotation).GetComponent<Enemy>();
            Destroy(Instantiate(_enemyT, _spawnerDOWN.position, _spawnerDOWN.rotation).gameObject, 1f);
        }
        
        if(enemyType == EnemyTypes.RED)
        {
            _enemy.sprite = _sprites[0];
            SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.EnemyRedNode);
        }
        else if(enemyType == EnemyTypes.BLUE)
        {
            SoundManager.instance.EffectSoundPlay((int)SoundManager.EffectType.EnemyBlueNode);
            _enemy.sprite = _sprites[1];
        }
        else if(enemyType == EnemyTypes.TRASH) _enemy.sprite = _sprites[2];
        _enemy.enemyType = enemyType;
        _enemy.spawnTime = spawnTime;
        _enemy.spawnSpeed = speed;
        _enemy.CharX = _char.position.x;
    }
}
