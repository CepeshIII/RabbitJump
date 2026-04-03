using System;
using UnityEngine;

public interface IInputManager
{
    public Action onJump { get; set; }
    public Action<Vector2> onMove { get; set; }
    Vector2 GetMovementInput();
}
