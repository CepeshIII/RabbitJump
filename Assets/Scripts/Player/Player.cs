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


    private void OnDisable()
    {
        onFall -= SwitchToFall;
        onJump -= SwitchToJump;
        onLand -= SwitchToIdle;
        onGameOver -= SwitchToGameOver;
    }


    private void SwitchToFall()
    {
        CurrentState = PlayerState.Falling;
    }


    private void SwitchToJump()
    {
        CurrentState = PlayerState.Jumping;
    }


    private void SwitchToIdle()
    {
        CurrentState = PlayerState.Idle;
    }


    private void SwitchToGameOver()
    {
        CurrentState = PlayerState.GameOver;
    }
}

