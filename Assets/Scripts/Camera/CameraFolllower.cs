using System;
using UnityEngine;
using Zenject;


public class CameraFollow: MonoBehaviour
{
    [SerializeField]
    [Range(0, 1)]
    private float yOffset = 0.5f;

    [SerializeField]
    private float speed = 10f;

    private Transform playerTransform;
    private CameraBorder cameraBorder;


    public Action OnBorderMoved { get; set; }



    [Inject]
    public void Construct(Player player, CameraBorder cameraBorder)
    {
        this.playerTransform = player.transform;
        this.cameraBorder = cameraBorder;
    }   


    private void Update()
    {
        var playerYPosition = playerTransform.transform.position.y;

        var topBorder = Mathf.Lerp(cameraBorder.Bottom, cameraBorder.Top, 1 - yOffset);

        if (topBorder <= playerYPosition)
        {
            transform.position = 
                Vector3.MoveTowards(
                    transform.position, 
                    new Vector3(transform.position.x, playerYPosition, transform.position.z),
                    speed * Time.deltaTime);

            OnBorderMoved?.Invoke();
            cameraBorder.Refresh();
        }
    }
}
