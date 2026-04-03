using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GamePlayUI: MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI scoreText;

    private GamePlayUIManager gamePlayUIManager;
    private ScoreCounter scoreCounter;


    [Inject]
    public void Construct(GamePlayUIManager gamePlayUIManager, ScoreCounter scoreCounter)
    {
        this.gamePlayUIManager = gamePlayUIManager;
        this.scoreCounter = scoreCounter;
    }


    public void Start()
    {
        if (menuButton != null)
            menuButton.onClick.AddListener(OnMenuButtonClicked);
    }


    private void OnEnable()
    {
        if (scoreCounter != null)
            scoreCounter.onScoreUpdated += UpdateScore;
    }


    private void OnDisable()
    {
        if (scoreCounter != null)
            scoreCounter.onScoreUpdated -= UpdateScore;
    }


    private void OnMenuButtonClicked()
    {
        gamePlayUIManager.ShowMenu();
    }


    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }


}
