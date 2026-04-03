using System.Collections.Generic;
using UnityEngine;


public class RecordLinesDisplayer : MonoBehaviour
{
    [SerializeField] RecordLineDisplayer linePrefab;

    private List<RecordLineDisplayer> lines = new();


    public void UpdateData(RecordList recordList)
    {
        if (recordList == null || recordList.records == null)
        {
            return;
        }

        recordList.SortByScoreDescending(); // Sort records by score in descending order

        for (var i = 0; i < Mathf.Min(recordList.records.Count, 4); i++)
        {
            if(lines.Count > i)
            {
                lines[i].UpdateData(recordList.records[i]);
            }
            else
            {
                var line = Instantiate(linePrefab, transform);
                line.UpdateData(recordList.records[i]);
                lines.Add(line);
            }
        }
    }
}
