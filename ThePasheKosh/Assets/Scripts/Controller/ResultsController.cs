using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsController : Singleton<ResultsController>
{
    public float Score { get; private set; }

    public int LevelFalseKillCounter { get; private set; } = 0;
    public int LevelTrueKillCounter { get; private set; } = 0;
    public int GameTrueKillCounter { get; private set; } = 0;
    public int GameFalseKillCounter { get; private set; } = 0;
    public int AllKills { get; private set; } = 0;

    void Start()
    {
        ResetScore();
    }

    ///<summary>
    /// Adding to the score, level, right and wrong selections
    /// </summary>
    public void AddToScore(float amount)
    {
        Score += amount;
        Score = Score >= 0 ? Score : 0;
    }
    public void TrueKill()
    {
        GameTrueKillCounter++;
        LevelTrueKillCounter++;
        AllKills++;
    }
    public void FalseKill()
    {
        GameFalseKillCounter++;
        LevelFalseKillCounter++;
        AllKills++;
    }

    /// <summary>
    /// Reset the score and counters
    /// </summary>
    public void ResetScore()
    {
        Score = 0;
        GameFalseKillCounter = 0;
        GameTrueKillCounter = 0;
        AllKills = 0;
    }
    public void ResetLevelCounters()
    {
        LevelTrueKillCounter = 0;
        LevelFalseKillCounter = 0;
    }

    /// <summary>
    /// Get user progress
    /// </summary>
    /// <returns>Float between 0 to 1</returns>
    public float GetProgress()
    {
        return 0.4f;
    }

    /// <summary>
    /// Get user performance to other users
    /// </summary>
    /// <returns>Float between 0 to 1</returns>
    public float GetPerformance()
    {
        return 0.6f;
    }

    /// <summary>
    /// Get percent of true answers in the whole game
    /// </summary>
    /// <returns>Percent between 0 to 1</returns>
    public float GetTruePercent()
    {
        if (AllKills > 0)
            return (float)GameTrueKillCounter / (float)(GameTrueKillCounter + GameFalseKillCounter);
        else
            return 0;
    }
}
