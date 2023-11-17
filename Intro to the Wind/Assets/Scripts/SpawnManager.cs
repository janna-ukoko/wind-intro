using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnMode
{
    Enemy,
    Enemy2,
    Coin
}


public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public static float previousSpawnPositionX;

    public static SpawnMode currentSpawnMode;


    private void Start()
    {
        previousSpawnPositionX = _player.transform.position.x;
    }


    private void Update()
    {
        if (_player.transform.position.x > previousSpawnPositionX)
        {
            ChangeSpawnMode();
        }
    }


    public void ChangeSpawnMode()
    {
        currentSpawnMode = (SpawnMode)(Random.Range(0, 3));

        if (currentSpawnMode == SpawnMode.Coin)
        {
            GetComponent<CoinSpawner>().enabled = true;
            GetComponent<EnemySpawner>().enabled = false;
        }

        else
        {
            GetComponent<EnemySpawner>().enabled = true;
            GetComponent<CoinSpawner>().enabled = false;
        }


    }

}
