using UnityEngine;
using Zenject;


public class GameEntryPoint : MonoBehaviour
{
    [Inject] private GamePlayService gamePlayService;
    [Inject] private GamePlayUIManager uiManager;
    [Inject] private CameraBorder cameraBorder;
    [Inject] private PlatformGenerator platformGenerator;
    [Inject] private PlatformPoolManager platformPoolManager;
    [Inject] private ScoreCounter scoreCounter;



    private void Awake()
    {
        cameraBorder.Initialize();
        platformPoolManager.Initialize();
        platformGenerator.Initialize();
        scoreCounter.Initialize();
        gamePlayService.Initialize();
        uiManager.ShowGame();

    }


    private void OnDestroy()
    {
        // Dispose services when scene is unloaded
        gamePlayService.Dispose();
    }
}
