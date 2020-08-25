using UnityEngine;

public static class ScoreRepo 
{
    #region Properties
    public static string allScoreKeyName { get { return allScoreRepo; } }
    #endregion

    #region Fields
    const string lastScoreRepo = "LastScoreRepo";
    const string highScoreRepo = "HighScoreRepo";
    const string allScoreRepo = "AllScoreRepo";
    static int scores;
    #endregion

    #region Public Methods

    public static void PushScore(int newScore)
    {
        if (newScore > 0)
        {
            //Sum the New score To The All Score Repository.
            scores = scores + newScore;
            Save(allScoreRepo, scores);

            //Setting the new score as Last Score.
            Save(lastScoreRepo, newScore);

            //Check if new Score is bigger than the last high score and Set it as the new High Score.
            int highScore = GetHighScore();
            if (newScore > highScore)
            {
                Save(highScoreRepo, newScore);
            }
        }
    }


    public static int GetAllScore()
    {
        return Retrive(allScoreRepo);
    }
    public static int GetLastScore()
    {
        return Retrive(lastScoreRepo);
    }
    public static int GetHighScore()
    {
        return Retrive(highScoreRepo);
    }
    #endregion




    #region Private Methods
    static bool HasScore(int Count)
    {
        if (scores >= Count)
        {
            return true;
        }
        return false;
    }

    static int Retrive(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    static void Save(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
    }




    #endregion
}//EndClasssss/SadeQ
  