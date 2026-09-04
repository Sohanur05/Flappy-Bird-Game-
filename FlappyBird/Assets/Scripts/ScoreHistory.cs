using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ScoreHistory : MonoBehaviour
{
    public GameObject historyCanvas;
    public GameObject startCanvas;
    public TextMeshProUGUI historyText;

    private GameDatabase database;

    void Awake()
    {
        database = new GameDatabase();
    }

    public void ShowHistory()
    {
        startCanvas.SetActive(false);
        historyCanvas.SetActive(true);

        List<ScoreData> scores = database.GetAllScores();

        if (scores.Count == 0)
        {
            historyText.text = "No games played yet.";
            return;
        }

        string result = "SCORE HISTORY\n\n";

        foreach (ScoreData data in scores)
        {
            result += "Score: " + data.Score +
                      "     " + data.Date + "\n";
        }

        historyText.text = result;
    }

    public void CloseHistory()
    {
        historyCanvas.SetActive(false);
        startCanvas.SetActive(true);
    }
}