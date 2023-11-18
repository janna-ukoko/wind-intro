using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    [SerializeField] float flightSpeed = 10f;
    [SerializeField] float verticalSpeed = 1f;

    [Range(0f, 1f)]
    [SerializeField] float verticalSpeedAcceleration = 1f;

    private bool _screenIsTouched;

    private int _lastFingerID = -1;


    public int CoinCount { get; private set; }

    [SerializeField] private TextMeshProUGUI _coinText;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        MouseControls();

        HandleTouch();

    }


    private void FixedUpdate()
    {
        HandleHorizontalFlight();

        HandleVerticalFlight();

    }


    private void HandleHorizontalFlight()
    {
        _rb.velocity = new Vector2(flightSpeed, _rb.velocity.y);
    }


    private void HandleVerticalFlight()
    {
        if (_screenIsTouched)
            _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Lerp(_rb.velocity.y, verticalSpeed, verticalSpeedAcceleration));
    }


    private void HandleTouch()
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
    }


    private void MouseControls()
    {
        if (Input.GetMouseButtonDown(0))
            _screenIsTouched = true;
        else if (Input.GetMouseButtonUp(0))
            _screenIsTouched = false;
    }


    #region Coin Counter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            CoinCount += 1;
            _coinText.text = "Coins: " + CoinCount.ToString();
        }
    }
    #endregion

}
