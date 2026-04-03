using UnityEngine;
using TMPro;
using Zenject;
using System;


public class ScoreCounter: IInitializable, ITickable
{
    private Transform player;


    private float _maxHeight;
    private int _currentScore;

    public Action<int> onScoreUpdated;


    [Inject]
    public void Construct(Player player)
    {
        this.player = player.transform;
    }


    public void Initialize()
    {
        _maxHeight = player.position.y;
        ResetScore();
    }


    public void Tick()
    {
        float currentHeight = player.position.y;

        if (currentHeight > _maxHeight)
        {
            _maxHeight = currentHeight;

            int newScore = Mathf.FloorToInt(_maxHeight);

            if (newScore != _currentScore)
            {
                UpdateScore(newScore);
            }
        }
    }


    public int GetScore()
    {
        return _currentScore;
    }


    public void ResetScore()
    {
        _maxHeight = player.position.y;
        UpdateScore(0);
    }


    public void UpdateScore(int newScore)
    {
        _currentScore = newScore;
        onScoreUpdated?.Invoke(_currentScore);
    }


}