using System;
using UnityEngine;
using Zenject;


public class MainMenuManager : MonoBehaviour, IInitializable, IDisposable
{
    private MainMenuUI mainMenuUI;
    private PrivacyUI privacyUI;
    private RecordsUI recordsUI;

    private MySceneManager sceneManager; 
    private RecordsService recordsService;



    [Inject]
    public void Construct(MainMenuUI mainMenuUI, PrivacyUI privacyUI, 
        RecordsUI recordsUI, MySceneManager sceneManager, RecordsService recordsService)
    {
        this.mainMenuUI = mainMenuUI;
        this.privacyUI = privacyUI;
        this.sceneManager = sceneManager;
        this.recordsUI = recordsUI;
        this.recordsService = recordsService;
    }


    public void Initialize()
    {
        // Subscribe to UI events
        mainMenuUI.OnStartPressed += HandleStart;
        mainMenuUI.OnPrivacyPressed += HandlePrivacy;
        mainMenuUI.OnRecordsPressed += HandleRecords;

        privacyUI.OnBackPressed += HandleMainMenu;
        recordsUI.OnBackPressed += HandleMainMenu;

        HandleMainMenu();
    }


    public void Dispose()
    {
        mainMenuUI.OnStartPressed -= HandleStart;
        mainMenuUI.OnPrivacyPressed -= HandlePrivacy;
        mainMenuUI.OnRecordsPressed -= HandleRecords;

        privacyUI.OnBackPressed -= HandleMainMenu;
    }


    private void HandleStart()
    {
        sceneManager.LoadGameplay();
    }


    private void HandlePrivacy()
    {
        mainMenuUI.gameObject.SetActive(false);
        recordsUI.gameObject.SetActive(false);
        privacyUI.gameObject.SetActive(true);
    }


    private void HandleRecords()
    {
        recordsUI.UpdateRecords(recordsService.LoadRecords());

        mainMenuUI.gameObject.SetActive(false);
        privacyUI.gameObject.SetActive(false);
        recordsUI.gameObject.SetActive(true);
    }


    private void HandleMainMenu()
    {
        privacyUI.gameObject.SetActive(false);
        recordsUI.gameObject.SetActive(false);
        mainMenuUI.gameObject.SetActive(true);
    }
}
