using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;



public class NewInputManager : MonoBehaviour, IInputManager
{

    private InputSystem_Actions _inputSystem = null;

    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public Action onJump { get; set; }
    public Action<Vector2> onMove { get; set; }



    private void OnEnable()
    {
        _inputSystem = new();
        _inputSystem.GamePlay.Enable();

        _inputSystem.GamePlay.Jump.started += HandleJump;
        _inputSystem.GamePlay.Movement.performed += HandleMovement;

        _inputSystem.GamePlay.Touch.started += HandleTouch;
        _inputSystem.GamePlay.TouchMovement.performed += HandleTouchMove;
    }


    private void Update()
    {
        if (!_inputSystem.GamePlay.TouchMovement.inProgress)
        {
            MoveInput = Vector2.zero;
        }

    }


    private void OnDisable()
    {
        _inputSystem.GamePlay.Disable();

        _inputSystem.GamePlay.Jump.started -= HandleJump;
        _inputSystem.GamePlay.Movement.performed -= HandleMovement;
    }


    public Vector2 GetMovementInput()
    {
        throw new NotImplementedException();
    }


    private void HandleJump(InputAction.CallbackContext context)
    {
        //onJump?.Invoke();
    }


    private void HandleMovement(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
        onMove?.Invoke(MoveInput);
    }

    private void HandleTouch(InputAction.CallbackContext context)
    {
    }


    private void HandleTouchMove(InputAction.CallbackContext context)
    {
        var screenPosition = context.ReadValue<Vector2>();
        var screenSize = Screen.width;
        var normalizedX = Mathf.Clamp01(screenPosition.x / screenSize);
        var moveInput = new Vector2(normalizedX * 2 - 1, 0).normalized;
        MoveInput = moveInput;

        onMove?.Invoke(MoveInput);
    }
}
