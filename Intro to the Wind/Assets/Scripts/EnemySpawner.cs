using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject[] _enemyArray;
    [SerializeField] private float[] _enemyPositionRangeY;

    [SerializeField] private float _minDistanceBetweenEnemiesInAGroup = 10;
    [SerializeField] private float _maxDistanceBetweenEnemiesInAGroup = 20;

    [SerializeField] private float _minSpawnOffsetOfAnEnemyGroup = 100;
    [SerializeField] private float _maxSpawnOffsetOfAnEnemyGroup = 200;

    [SerializeField] private int _maxNoOfEnemiesPerGroup = 1;

    float _spawnOffset;

    float _spawnPositionX;

    float _previousSpawnPositionX ;

    int randomEnemyInt;


    void Start()
    {
        _previousSpawnPositionX = _player.transform.position.x; // Make it spawn more towards the player?
    }


    private void Update()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        if (_player.transform.position.x > _previousSpawnPositionX)
        {
            SpawnAnEnemyGroup();
        }
    }


    #region SPAWN AN ENEMY

    GameObject RandomizeEnemy()
    {
        randomEnemyInt = Random.Range(0, _enemyArray.Length);
        return _enemyArray[randomEnemyInt];
    }

    float RandomizeEnemyPositionY()
    {
        var enemyPositionY = Random.Range(-_enemyPositionRangeY[randomEnemyInt], _enemyPositionRangeY[randomEnemyInt]);
        return enemyPositionY;
    }


    void SpawnAnEnemy()
    {
        var spawnedEnemy = Instantiate(RandomizeEnemy(), transform);

        _spawnPositionX = _previousSpawnPositionX + _spawnOffset;

        spawnedEnemy.transform.position = new Vector2(_spawnPositionX, RandomizeEnemyPositionY());

        _previousSpawnPositionX = spawnedEnemy.transform.position.x;
    }

    #endregion


    #region SPAWN AN EMEMY GROUP

    void SpawnAnEnemyGroup()
    {
        var numberOfEnemiesPerGroup = Random.Range(1, _maxNoOfEnemiesPerGroup + 1);

        for (int i = 1; i <= numberOfEnemiesPerGroup; i++)
        {
            if (i == 1)
                _spawnOffset = Random.Range(_minSpawnOffsetOfAnEnemyGroup, _maxSpawnOffsetOfAnEnemyGroup);

            else
                _spawnOffset = Random.Range(_minDistanceBetweenEnemiesInAGroup, _maxDistanceBetweenEnemiesInAGroup);


            SpawnAnEnemy();

        }
    }

    #endregion
}
