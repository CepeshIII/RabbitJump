using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RecordsUI : MonoBehaviour
{
    [SerializeField] private Button backButton;

    private RecordLinesDisplayer recordLinesDisplayer;

    public event Action OnBackPressed;



    [Inject]
    public void Construct(RecordLinesDisplayer recordLinesDisplayer)
    {
        this.recordLinesDisplayer = recordLinesDisplayer;
    }


    private void OnEnable()
    {
        backButton.onClick.AddListener(OnReturnButtonPressed);
    }


    private void OnDisable()
    {
        backButton.onClick.RemoveAllListeners();
    }


    public void UpdateRecords(RecordList recordList)
    {
        recordLinesDisplayer.UpdateData(recordList);
    }


    public void OnReturnButtonPressed()
    {
        OnBackPressed?.Invoke();
    }
}
