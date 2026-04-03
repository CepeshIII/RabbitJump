using TMPro;
using UnityEngine;


public class RecordLineDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dataText;
    [SerializeField] TextMeshProUGUI recordValueText;



    public void UpdateData(Record record)
    {
        if (record == null)
        {
            return;
        }
     
        if(dataText != null)
        {
            dataText.text = record.date;
        }

        if(recordValueText != null)
        {
            recordValueText.text = $"{record.score} m";

        }
    }
}
