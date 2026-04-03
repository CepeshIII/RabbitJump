using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MainMenuUI : MonoBehaviour, IInitializable, IDisposable
{
    [Header("Buttons")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button recordsButton;
    [SerializeField] private Button privacyButton;

    public event Action OnStartPressed;
    public event Action OnRecordsPressed;
    public event Action OnPrivacyPressed;



    public void Initialize()
    {
        startButton.onClick.AddListener(OnStartClicked);
        recordsButton.onClick.AddListener(OnRecordsClicked);
        privacyButton.onClick.AddListener(OnPrivacyClicked);
    }


    public void Dispose()
    {
        startButton.onClick.RemoveListener(OnStartClicked);
        recordsButton.onClick.RemoveListener(OnRecordsClicked);
        privacyButton.onClick.RemoveListener(OnPrivacyClicked);
    }


    private void OnStartClicked()
    {
        OnStartPressed?.Invoke();
    }


    private void OnRecordsClicked()
    {
        OnRecordsPressed?.Invoke();
    }


    private void OnPrivacyClicked()
    {
        OnPrivacyPressed?.Invoke();
    }
}