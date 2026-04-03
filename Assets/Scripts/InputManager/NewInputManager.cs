using System;
using UnityEngine;
using UnityEngine.InputSystem;



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
        onJump?.Invoke();
    }


    private void HandleMovement(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
        onMove?.Invoke(MoveInput);
    }
 
}
