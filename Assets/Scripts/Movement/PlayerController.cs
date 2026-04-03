using System;
using UnityEngine;
using Zenject;


public class PlayerController: MonoBehaviour
{
    private IInputManager inputManager;
    private IMovement movement;



    [Inject]
    public void Construct(IInputManager inputManager, IMovement movement)
    {
        this.inputManager = inputManager;
        this.movement = movement;
    }

}

