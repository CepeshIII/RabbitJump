using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Record
{
    public int score;
    public string date;
}

[System.Serializable]
public class RecordList
{
    public List<Record> records = new List<Record>();

    public void SortByScoreDescending()
    {
            records.Sort((a, b) => b.score.CompareTo(a.score));
    }
}


public class RecordsService
{
    private const string KEY = "records";

    public void SaveRecord(int score)
    {
        var list = LoadRecords();

        list.records.Add(new Record
        {
            score = score,
            date = System.DateTime.Now.ToString("MM-dd"),
        });

        string json = JsonUtility.ToJson(list);
        PlayerPrefs.SetString(KEY, json);
        PlayerPrefs.Save();
    }

    public RecordList LoadRecords()
    {
        if (!PlayerPrefs.HasKey(KEY))
            return new RecordList();

        return JsonUtility.FromJson<RecordList>(PlayerPrefs.GetString(KEY));
    }
}