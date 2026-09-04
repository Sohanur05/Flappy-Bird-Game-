using UnityEngine;
using SQLite;
using System.IO;
using System.Collections.Generic;

public class GameDatabase
{  private SQLiteConnection db;

    public GameDatabase()
    {
        string path = Path.Combine(
            Application.persistentDataPath,
            "FlappyBird.db" );

        db = new SQLiteConnection(path);

        db.CreateTable<ScoreData>();}
    public void SaveScore(int score)
    {
        ScoreData data = new ScoreData
        {
            Score = score,
            Date = System.DateTime.Now.ToString("dd/MM/yyyy HH:mm")
        };

        db.Insert(data);}
    public int GetHighScore()
    {
        var scores = db.Table<ScoreData>();

        int highScore = 0;

        foreach (var item in scores)
        {
            if (item.Score > highScore)
            {
                highScore = item.Score;
            }
        }

        return highScore;
    }

   
    public List<ScoreData> GetAllScores()
    {
        return db.Table<ScoreData>()
                 .OrderByDescending(x => x.Id)
                 .ToList(); }}public class ScoreData
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Score { get; set; }

    public string Date { get; set; }
}