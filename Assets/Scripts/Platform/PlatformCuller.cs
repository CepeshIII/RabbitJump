using System;
using UnityEngine;
using Zenject;


public class PlatformCuller: MonoBehaviour, IInitializable, IDisposable
{
    [SerializeField] 
    [Range(0f, 1f)]
    private float viewportOffset = 0.25f;

    private PlatformPoolManager platformPoolManager;
    private CameraBorder cameraBorder;
    private CameraFollow cameraFollow;


    [Inject]
    public void Construct(PlatformPoolManager platformPoolManager, 
        CameraBorder cameraBorder, CameraFollow cameraFollow)
    {
        this.platformPoolManager = platformPoolManager;
        this.cameraBorder = cameraBorder;
        this.cameraFollow = cameraFollow;

    }


    public void Initialize()
    {
        cameraFollow.OnBorderMoved += OnBorderMovedHandler;
    }


    public void Dispose()
    {
        cameraFollow.OnBorderMoved -= OnBorderMovedHandler;
    }


    private void OnBorderMovedHandler()
    {
        platformPoolManager.HideBelowY(
            Mathf.LerpUnclamped(cameraBorder.Bottom, cameraBorder.Top, - viewportOffset));
    }
}
