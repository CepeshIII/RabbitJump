using System;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEngine;
using Zenject;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private GameObject bigPlatformPrefab;
    [SerializeField] private GameObject smallPlatformPrefab;

    [SerializeField] private float minDistanceBetweenPlatforms = 2.5f;
    [SerializeField] private float maxDistanceBetweenPlatforms = 5;

    [SerializeField, Range(0, 1)] 
    private float horizontalBorderOffset;

    [SerializeField, Range(0, 1)]
    private float topBorderOffset;


    private PlatformPoolManager poolManager;
    private Transform player;
    private CameraBorder cameraBorder;
    private float lastSpawnY;


    [Inject]
    public void Construct(Player player, 
        CameraBorder cameraBorder, PlatformPoolManager platformPoolManager)
    {
        this.player = player.transform;
        this.cameraBorder = cameraBorder;
        this.poolManager = platformPoolManager;
    }


    private void Start()
    {
        lastSpawnY = cameraBorder.Bottom;
        SpawnInitialPlatforms();
    }


    private void Update()
    {
        if (lastSpawnY <= Mathf.Lerp(cameraBorder.Bottom, cameraBorder.Top, 1 + topBorderOffset))
        {
            SpawnPlatform();
        }
    }


    public void SpawnInitialPlatforms()
    {
        while (lastSpawnY < 
            Mathf.Lerp(cameraBorder.Bottom, cameraBorder.Top, 1 + topBorderOffset))
        {
            SpawnPlatform();
        }
    }


    private void SpawnPlatform()
    {
        var leftBorder = Mathf.Lerp(
                    cameraBorder.Left,
                    cameraBorder.Right,
                    horizontalBorderOffset);

        var rightBorder = Mathf.Lerp(
            cameraBorder.Left,
            cameraBorder.Right,
            1 - horizontalBorderOffset);

        var randomValue = UnityEngine.Random.Range(0f, 1f);
        float x =  Mathf.Lerp(
                    leftBorder,
                    rightBorder,
                    randomValue);

        var distance = UnityEngine.Random.Range(minDistanceBetweenPlatforms, maxDistanceBetweenPlatforms);
        float y = lastSpawnY + distance;

        bool isBig = UnityEngine.Random.value > 0.3f;

        poolManager.GetPlatform(isBig, new Vector3(x, y, 0));

        lastSpawnY = y;
    }

}
