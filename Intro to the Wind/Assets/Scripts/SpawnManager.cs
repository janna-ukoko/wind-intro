using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnMode
{
    Enemy,
    Coin
}


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public static float previousSpawnPositionX;

    public static SpawnMode currentSpawnMode;

    public static int enemySpawnsInARow = 0;

    public static int coinSpawnsInARow = 0;

    public static bool canChangeSpawnMode = true;

    [SerializeField] private int enemySpawnLimit = 4;

    [SerializeField] private int coinSpawnLimit = 2;


    private void Start()
    {
        previousSpawnPositionX = _player.transform.position.x;
    }


    private void Update()
    {
        if (_player.transform.position.x > previousSpawnPositionX && canChangeSpawnMode)
        {
            LimitSpawnsInARow();

            ChangeSpawnMode();

            canChangeSpawnMode = false;
        }
    }


    private void ChangeSpawnMode()
    {
        if (enemySpawnsInARow < enemySpawnLimit && coinSpawnsInARow < coinSpawnLimit)
            currentSpawnMode = (SpawnMode)Random.Range(0, 2);

        if (currentSpawnMode == SpawnMode.Coin)
        {
            GetComponent<CoinSpawner>().enabled = true;
            GetComponent<EnemySpawner>().enabled = false;

            enemySpawnsInARow = 0;
        }

        else
        {
            GetComponent<EnemySpawner>().enabled = true;
            GetComponent<CoinSpawner>().enabled = false;

            coinSpawnsInARow = 0;
        }
    }


    private void LimitSpawnsInARow()
    {
        if (enemySpawnsInARow == enemySpawnLimit)
            currentSpawnMode = SpawnMode.Coin;

        if (coinSpawnsInARow == coinSpawnLimit)
            currentSpawnMode = SpawnMode.Enemy;
    }

}
