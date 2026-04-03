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


    public void OnEnable()
    {
        if (resumeButton != null)
            resumeButton.onClick.AddListener(OnResumeButtonClicked);

        if (exitButton != null)
            exitButton.onClick.AddListener(OnExitButtonClicked);
    }


    public void OnDisable()
    {
        if (resumeButton != null)
            resumeButton.onClick.RemoveListener(OnResumeButtonClicked);
        if (exitButton != null)
            exitButton.onClick.RemoveListener(OnExitButtonClicked);
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
