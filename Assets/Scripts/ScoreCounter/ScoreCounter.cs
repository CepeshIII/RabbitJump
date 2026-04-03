using UnityEngine;
using TMPro;
using Zenject;


public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private TMP_Text scoreText;


    private float _maxHeight;
    private int _currentScore;



    [Inject]
    public void Construct(Player player)
    {
        this.player = player.transform;
    }


    private void Start()
    {
        _maxHeight = player.position.y;
        UpdateUI(0);
    }


    private void Update()
    {
        float currentHeight = player.position.y;

        if (currentHeight > _maxHeight)
        {
            _maxHeight = currentHeight;

            int newScore = Mathf.FloorToInt(_maxHeight);

            if (newScore != _currentScore)
            {
                _currentScore = newScore;
                UpdateUI(_currentScore);
            }
        }
    }


    private void UpdateUI(int score)
    {
        scoreText.text = score.ToString();
    }


    public int GetScore()
    {
        return _currentScore;
    }


    public void ResetScore()
    {
        _maxHeight = player.position.y;
        _currentScore = 0;
        UpdateUI(0);
    }
}