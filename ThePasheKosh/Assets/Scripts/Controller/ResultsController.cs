using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsController : Singleton<ResultsController>
{
    public int Score { get; private set; }
    public int LevelFalseAnswersCounter { get; private set; } = 0;
    public int LevelTrueAnswersCounter { get; private set; } = 0;
    public int GameTrueAnswerCounter { get; private set; } = 0;
    public int GameFalseAnswerCounter { get; private set; } = 0;
    public int AllAnswers { get; private set; } = 0;

    void Start()
    {
        ResetScore();
    }

    ///<summary>
    /// Adding to the score, level, right and wrong selections
    /// </summary>
    public void AddToScore(int amount)
    {
        Score += amount;
    }
    public void AddToTrueSelections()
    {
        GameTrueAnswerCounter++;
        LevelTrueAnswersCounter++;
        AllAnswers++;
    }
    public void AddToFalseSelections()
    {
        GameFalseAnswerCounter++;
        LevelFalseAnswersCounter++;
        AllAnswers++;
    }
    /// <summary>
    ///  Subtract from the score
    /// </summary>
    public void SubtractFromScore(int amount)
    {
        Score -= Score - amount >= 0 ? amount : Score;
    }

    /// <summary>
    /// Reset the score and counters
    /// </summary>
    public void ResetScore()
    {
        Score = 0;
        GameFalseAnswerCounter = 0;
        GameTrueAnswerCounter = 0;
    }
    public void ResetWrongAndRightSelectionCounters()
    {
        LevelTrueAnswersCounter = 0;
        LevelFalseAnswersCounter = 0;
        AllAnswers = 0;
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
        if (AllAnswers > 0)
            return (float)GameTrueAnswerCounter / (float)(GameTrueAnswerCounter + GameFalseAnswerCounter);
        else
            return 0;
    }
}
