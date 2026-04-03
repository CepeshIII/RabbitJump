using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;


public class MySceneManager : MonoBehaviour, IInitializable
{
    public static MySceneManager Instance;

    public const int MENU_SCENE_ID = 0;
    public const int GAMEPLAY_SCENE_ID = 1;

    private LoadingSceneUI loadingSceneIU;


    public void LoadMenu() => StartCoroutine(LoadAsync(MENU_SCENE_ID));
    public void LoadGameplay() => StartCoroutine(LoadAsync(GAMEPLAY_SCENE_ID));


    [Inject]
    public void Construct(LoadingSceneUI loadingSceneIU)
    {
        this.loadingSceneIU = loadingSceneIU;
    }


    public void Initialize()
    {
        loadingSceneIU.Hide();
    }


    private IEnumerator LoadAsync(int sceneID)
    {
        UnPause();
        loadingSceneIU.Show();
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSceneIU.SetFillAmount(progress);
            yield return null;
        }
        loadingSceneIU.Hide();
    }


    public void QuitGame()
    {
        Application.Quit();
    }


    public void Pause()
    {
        Time.timeScale = 0f;
    }

    
    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}