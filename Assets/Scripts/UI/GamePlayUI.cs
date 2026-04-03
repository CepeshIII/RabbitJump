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


    private void OnEnable()
    {
        if (menuButton != null)
            menuButton.onClick.AddListener(OnMenuButtonClicked);
        if (scoreCounter != null)
            scoreCounter.onScoreUpdated += UpdateScore;
    }


    private void OnDisable()
    {
        if (menuButton != null)
            menuButton.onClick.RemoveListener(OnMenuButtonClicked);
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
