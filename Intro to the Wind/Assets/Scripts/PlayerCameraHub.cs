using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraHub : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;

    void FixedUpdate()
    {
        transform.position = new Vector2(_playerTransform.position.x, 0);
    }

}
