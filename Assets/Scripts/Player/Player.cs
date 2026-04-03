using System;
using UnityEngine;


public class Player: MonoBehaviour
{
    public Action onFall;
    public Action onJump;
    public Action onLand;
    public Action onGameOver;

    public PlayerState CurrentState { get; private set; }


    private void OnEnable()
    {
        onFall += SwitchToFall;
        onJump += SwitchToJump;
        onLand += SwitchToIdle;
        onGameOver += SwitchToGameOver;
    }


    private void Start()
    {
        
    }


    private void OnDisable()
    {
        onFall -= SwitchToFall;
        onJump -= SwitchToJump;
        onLand -= SwitchToIdle;
        onGameOver -= SwitchToGameOver;
    }


    private void SwitchToFall()
    {
        Debug.Log("Fall");

        CurrentState = PlayerState.Falling;
    }


    private void SwitchToJump()
    {
        Debug.Log("Jump");
        CurrentState = PlayerState.Jumping;
    }


    private void SwitchToIdle()
    {
        Debug.Log("Idle");
        CurrentState = PlayerState.Idle;
    }


    private void SwitchToGameOver()
    {
        Debug.Log("Game Over");
        CurrentState = PlayerState.GameOver;
    }
}

