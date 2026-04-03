using System;
using UnityEngine;
using Zenject;


public class PlayerController: MonoBehaviour, IInitializable, ITickable, IDisposable
{
    [SerializeField, Range(0f, 1f)]
    public float gameOverThresholdY = 0.1f;

    private IInputManager input;
    private IMovement movement;
    private CameraBorder cameraBorder;
    private Player player;



    [Inject]
    public void Construct(
        IInputManager input,
        IMovement movement,
        CameraBorder cameraBorder,
        Player player)
    {
        this.input = input;
        this.movement = movement;
        this.cameraBorder = cameraBorder;
        this.player = player;
    }


    public void Initialize()
    {
        input.onMove += OnMove;
        input.onJump += OnJump;
    }


    public void Tick()
    {
        if(player.CurrentState == PlayerState.GameOver) return;

        HandleBounds();
        HandleState();
    }


    public void Dispose()
    {
        input.onMove -= OnMove;
        input.onJump -= OnJump;
    }

    private void OnMove(Vector2 dir)
    {
        movement.Move(dir);
    }


    private void OnJump()
    {
        if (player.CurrentState != PlayerState.Idle) return;

        player.onJump?.Invoke();
        movement.Jump();
    }


    private void HandleBounds()
    {
        var position = movement.GetPosition();

        // Horizontal wrap
        if (cameraBorder.IsOutsideHorizontal(position))
        {
            float normalizedX = Mathf.InverseLerp(cameraBorder.Left, cameraBorder.Right, position.x);
            float invertedNormalizedX = 1f - normalizedX;
            float newX = Mathf.Lerp(cameraBorder.Left, cameraBorder.Right, invertedNormalizedX);

            movement.SetPositionX(newX);
        }

        // Game over
        if (Mathf.LerpUnclamped(cameraBorder.Bottom, cameraBorder.Top, -gameOverThresholdY) > position.y)
        {
            player.onGameOver?.Invoke();
        }
    }


    private void HandleState()
    {
        if (player.CurrentState == PlayerState.Jumping)
        {
            if (movement.GetVelocity().y < 0) // or better velocity check
            {
                player.onFall?.Invoke();
            }
        }
        else if (player.CurrentState == PlayerState.Idle)
        {
            OnJump();
        }
    }

}

