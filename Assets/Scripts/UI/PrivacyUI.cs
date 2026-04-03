using System;
using UnityEngine;
using UnityEngine.UI;


public class PrivacyUI : MonoBehaviour
{
    [SerializeField] private Button backButton;

    public event Action OnBackPressed;



    private void OnEnable()
    {
        backButton.onClick.AddListener(OnReturnButtonPressed);
    }


    private void OnDisable()
    {
        backButton.onClick.RemoveAllListeners();
    }


    public void OnReturnButtonPressed()
    {
        OnBackPressed?.Invoke();
    }
}
