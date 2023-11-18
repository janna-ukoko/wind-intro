using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("GameManager is NULL");
            }

            return _instance;

        }
    }

    private void Awake()
    {
        if (_instance)
            Destroy(gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(this);
    }
    #endregion


    [SerializeField] private PlayerController _player;

    private void Update()
    {
        //CoinManager();
    }

    private void CoinManager()
    {
        print(_player.CoinCount);
    }
}
