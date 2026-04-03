using System;
using System.Collections;
using UnityEngine;
using Zenject;


public class GamePlayUIManager : MonoBehaviour
{
    private GamePlayUI gamePlayUI;
    private GameOverUI gameOverUI;
    private MenuUI menuUI;
    private MySceneManager sceneManager;


    public Action onGameQuitted;


    [Inject]
    public void Construct(GamePlayUI gamePlayUI,    
        GameOverUI gameOverUI, MenuUI menuUI, MySceneManager mySceneManager)
    {
        this.gamePlayUI = gamePlayUI;
        this.gameOverUI = gameOverUI;
        this.menuUI = menuUI;
        this.sceneManager = mySceneManager;
    }


    private void Awake()
    {
        ShowGame();
    }


    public void ShowMenu()
    {
        sceneManager.Pause();
        SetActive(menuUI, true);
        SetActive(gamePlayUI, false);
        SetActive(gameOverUI, false);
    }


    public void ShowGame()
    {
        sceneManager.UnPause();
        SetActive(menuUI, false);
        SetActive(gamePlayUI, true);
        SetActive(gameOverUI, false);
    }


    public void ShowGameOver(int score)
    {
        SetActive(menuUI, false);
        SetActive(gamePlayUI, false);
        SetActive(gameOverUI, true);

        gameOverUI.SetScore(score);
    }


    public void ShowGameOverDelayed(int score, float delay)
    {
        StartCoroutine(ShowGameOverWithDelay(score, delay));
    }


    private IEnumerator ShowGameOverWithDelay(int score, float delay)
    {
        yield return new WaitForSeconds(delay);
        ShowGameOver(score);
    }

    private void SetActive(MonoBehaviour ui, bool value)
    {
        if (ui != null)
            ui.gameObject.SetActive(value);
    }


    public void RestartGame()
    {
        sceneManager.LoadGameplay();
    }


    public void Exit()
    {
        onGameQuitted?.Invoke();
        sceneManager.LoadMenu();
        //sceneManager.QuitGame();
    }

}