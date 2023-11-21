using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectile : Enemy
{
    [SerializeField] Rigidbody2D rb;

    private GameObject _player;

    private GameObject _projectileWarningImage;

    private GameObject _canvas;

    private float _speed = 30;


    void Update()
    {
        MoveProjectile();
    }


    void MoveProjectile()
    {
        rb.velocity = Vector2.left * _speed;
    }

}
