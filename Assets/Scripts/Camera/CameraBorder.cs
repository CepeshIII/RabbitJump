using System;
using UnityEngine;

public class CameraBorder : MonoBehaviour
{
    private Camera mainCamera;

    public float Left { get; private set; }
    public float Right { get; private set; }
    public float Top { get; private set; }
    public float Bottom { get; private set; }



    public void Initialize()
    {
        mainCamera = GetComponent<Camera>();

        if (mainCamera == null)
            mainCamera = Camera.main;

        CalculateBounds();
    }


    private void CalculateBounds()
    {
        float z = Mathf.Abs(mainCamera.transform.position.z);

        Vector3 bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, z));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, z));

        Left = bottomLeft.x;
        Bottom = bottomLeft.y;
        Right = topRight.x;
        Top = topRight.y;
    }


    /// <summary>
    /// Recalculate bounds (call if screen size changes)
    /// </summary>
    public void Refresh()
    {
        CalculateBounds();
    }


    /// <summary>
    /// Check if position is outside camera view
    /// </summary>
    public bool IsOutside(Vector3 position)
    {
        return IsOutsideHorizontal(position) && IsOutsideVertical(position);
    }


    public bool IsOutsideHorizontal(Vector3 position)
    {
        return position.x < Left ||
               position.x > Right;
    }


    public bool IsOutsideVertical(Vector3 position)
    {
        return position.y < Bottom ||
               position.y > Top;
    }


    /// <summary>
    /// Clamp position inside camera bounds
    /// </summary>
    public Vector3 ClampPosition(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, Left, Right);
        position.y = Mathf.Clamp(position.y, Bottom, Top);
        return position;
    }


    /// <summary>
    /// Horizontal wrap (useful for Doodle Jump)
    /// </summary>
    public Vector3 WrapHorizontal(Vector3 position)
    {
        if (position.x < Left)
            position.x = Right;
        else if (position.x > Right)
            position.x = Left;

        return position;
    }
}

