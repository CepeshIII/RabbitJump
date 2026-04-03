using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;
    [SerializeField] private Button restartGameButton;

    private GamePlayUIManager gamePlayUIManager;



    [Inject]
    public void Construct(GamePlayUIManager gamePlayUIManager)
    {
        this.gamePlayUIManager = gamePlayUIManager;
    }


    public void OnEnable()
    {
        if (restartGameButton != null)
            restartGameButton.onClick.AddListener(OnRestartGameButtonClicked);
    }


    public void OnDisable()
    {
        if (restartGameButton != null)
            restartGameButton.onClick.RemoveListener(OnRestartGameButtonClicked);
    }


    private void OnRestartGameButtonClicked()
    {
        gamePlayUIManager.RestartGame();
    }


    public void SetScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Score: {score}";
    }

}
