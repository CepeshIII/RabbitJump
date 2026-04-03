using UnityEngine;

public interface IMovement
{
    public void Jump();
    public void Move(Vector2 direction);
    public void SetPositionX(float x);
    public Vector2 GetVelocity();
    public Vector2 GetPosition();



}

