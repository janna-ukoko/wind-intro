using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Joystick _joystick;

    private Rigidbody2D _rb;

    [SerializeField] float flightSpeed = 10f;
    [SerializeField] float verticalSpeed = 1f;

    [Range(0f, 1f)]
    [SerializeField] float verticalSpeedAcceleration = 1f;

    private bool _screenIsTouched;

    private int _lastFingerID = -1;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        HandleHorizontalFlight();

        HandleTouchMovement();
    }


    private void HandleHorizontalFlight()
    {
        _rb.velocity = new Vector2(flightSpeed, _rb.velocity.y);
    }


    private void HandleTouchMovement()
    {
        foreach (Touch touch in Input.touches)
        {

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _screenIsTouched = true;
                    _lastFingerID = touch.fingerId;
                    break;

                case TouchPhase.Ended:
                    if (touch.fingerId == _lastFingerID)
                        _screenIsTouched = false;
                    break;
            }

        }

        if (_screenIsTouched)
            _rb.velocity = new Vector2(_rb.velocity.x, 20); // Add acceleration and deceleration

    }
}
