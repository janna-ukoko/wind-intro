using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float flightSpeed = 10f;
    [SerializeField] float verticalSpeed = 1f;

    private float moveDirection;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        moveDirection = Input.GetAxis("Vertical");
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(flightSpeed, moveDirection * verticalSpeed);
    }
}
