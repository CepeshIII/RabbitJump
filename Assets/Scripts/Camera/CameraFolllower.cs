using System;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField, Range(0, 1)]
    private float yOffset = 0.5f;

    [SerializeField]
    private float smoothTime = 0.2f; 

    private Transform playerTransform;
    private CameraBorder cameraBorder;

    private float velocityY; 

    public Action OnBorderMoved { get; set; }

    [Inject]
    public void Construct(Player player, CameraBorder cameraBorder)
    {
        this.playerTransform = player.transform;
        this.cameraBorder = cameraBorder;
    }

    private void Update()
    {
        float playerY = playerTransform.position.y;
        float triggerY = Mathf.Lerp(cameraBorder.Bottom, cameraBorder.Top, 1 - yOffset);

        if (playerY > triggerY)
        {
            float targetY = playerY;

            float newY = Mathf.SmoothDamp(
                transform.position.y,
                targetY,
                ref velocityY,
                smoothTime
            );

            transform.position = new Vector3(
                transform.position.x,
                newY,
                transform.position.z
            );

            OnBorderMoved?.Invoke();
            cameraBorder.Refresh();
        }
    }
}