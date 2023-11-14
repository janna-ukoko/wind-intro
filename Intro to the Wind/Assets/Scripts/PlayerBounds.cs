using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    [SerializeField] private Transform _player;


    void Update()
    {
        transform.position = new Vector2(_player.position.x, transform.position.y);

    }
}

