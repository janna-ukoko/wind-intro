using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject[] _coinArray;
    [SerializeField] private float[] _coinPositionRangeY;

    [SerializeField] private float _minDistanceBetweenCoinsInAGroup = 10;
    [SerializeField] private float _maxDistanceBetweenCoinsInAGroup = 20;

    [SerializeField] private float _minSpawnOffsetOfACoinGroup = 100;
    [SerializeField] private float _maxSpawnOffsetOfACoinGroup = 200;

    [SerializeField] private int _maxNoOfCoinsPerGroup = 1;

    float _spawnOffset;

    float _spawnPositionX;

    int randomCoinInt;


    private void Update()
    {
        SpawnCoins();
    }

    void SpawnCoins()
    {
        if (_player.transform.position.x > SpawnManager.previousSpawnPositionX)
        {
            SpawnAnCoinGroup();
        }
    }


    #region SPAWN A COIN

    GameObject RandomizeCoin()
    {
        randomCoinInt = Random.Range(0, _coinArray.Length);
        return _coinArray[randomCoinInt];
    }

    float RandomizeCoinPositionY()
    {
        var coinPositionY = Random.Range(-_coinPositionRangeY[randomCoinInt], _coinPositionRangeY[randomCoinInt]);
        return coinPositionY;
    }


    void SpawnACoin()
    {
        var spawnedCoin = Instantiate(RandomizeCoin(), transform);

        _spawnPositionX = SpawnManager.previousSpawnPositionX + _spawnOffset;

        spawnedCoin.transform.position = new Vector2(_spawnPositionX, RandomizeCoinPositionY());

        SpawnManager.previousSpawnPositionX = spawnedCoin.transform.position.x;
    }

    #endregion


    #region SPAWN AN COIN GROUP

    void SpawnAnCoinGroup()
    {
        var numberOfCoinsPerGroup = Random.Range(1, _maxNoOfCoinsPerGroup + 1);

        for (int i = 1; i <= numberOfCoinsPerGroup; i++)
        {
            if (i == 1)
                _spawnOffset = Random.Range(_minSpawnOffsetOfACoinGroup, _maxSpawnOffsetOfACoinGroup);

            else
                _spawnOffset = Random.Range(_minDistanceBetweenCoinsInAGroup, _maxDistanceBetweenCoinsInAGroup);


            SpawnACoin();

        }
    }

    #endregion
}
