using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class GamePlayService: IInitializable, IDisposable
{
    private Player player;
    private ScoreCounter scoreCounter;
    private GamePlayUIManager gamePlayUIManager;
    private RecordsService recordsService;



    [Inject]
    public GamePlayService(Player player, ScoreCounter scoreCounter, 
        GamePlayUIManager gamePlayUIManager, RecordsService recordsService)
    {
        this.player = player;
        this.scoreCounter = scoreCounter;
        this.gamePlayUIManager = gamePlayUIManager;
        this.recordsService = recordsService;
    }


    public void Initialize()
    {
        if(player != null)
        {
            player.onGameOver += OnGameOver;
        }

        if(gamePlayUIManager != null)
        {
            gamePlayUIManager.onGameQuitted += SaveRecord;
        }
    }


    public void Dispose()
    {
        if (player != null)
        {
            player.onGameOver -= OnGameOver;
        }
    }


    private void SaveRecord()
    {
        var score = scoreCounter.GetScore();
        recordsService.SaveRecord(score);
    }


    private void OnGameOver()
    {
        var score = scoreCounter.GetScore();
        recordsService.SaveRecord(score);
        gamePlayUIManager.ShowGameOverDelayed(score, 2f);
    }

}
