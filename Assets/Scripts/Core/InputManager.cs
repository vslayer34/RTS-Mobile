using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    private InputAction _oneTouch;
    private InputAction _holdTouch;

    [SerializeField, Tooltip("Input values Container")]
    private SO_InputTracker _InputTracker;


    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _oneTouch = _playerInput.Controls.OneTouch;
        _holdTouch = _playerInput.Controls.HoldTouch;
    }


    private void Start()
    {
        _oneTouch.started += (ctx) =>
        {
            _InputTracker.touchPosition = GetTouchPosition(Touchscreen.current.primaryTouch.position.ReadValue());
            _InputTracker.onOneTouch?.Invoke();
        };

        _holdTouch.performed += (ctx) => { _InputTracker.onHoldTouch?.Invoke(); };
    }

    private Vector3 GetTouchPosition(Vector2 touchPosition)
    {
        
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        worldPosition.z = 0;
        return worldPosition;
    } 
}
