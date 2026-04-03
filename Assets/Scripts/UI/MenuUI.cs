using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class MenuUI : MonoBehaviour
{
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button exitButton;

    private GamePlayUIManager gamePlayUIManager;



    [Inject]
    public void Construct(GamePlayUIManager gamePlayUIManager)
    {
        this.gamePlayUIManager = gamePlayUIManager;
    }


    public void Start()
    {
        if (resumeButton != null)
            resumeButton.onClick.AddListener(OnResumeButtonClicked);

        if (exitButton != null)
            exitButton.onClick.AddListener(OnExitButtonClicked);
    }


    private void OnExitButtonClicked()
    {
        gamePlayUIManager.Exit();
    }


    private void OnResumeButtonClicked()
    {
        gamePlayUIManager.ShowGame();
    }
}
