using UnityEngine;

public static class ScoreRepo
{
    #region Properties
    public static string AllScoreRepoKey { get { return allScoreRepo; } }
    #endregion

    #region Fields
    const string lastScoreRepo = "LastScoreRepo";
    const string highScoreRepo = "HighScoreRepo";
    const string allScoreRepo = "AllScoreRepo";
    #endregion

    #region Public Methods

    public static void PushScore(float latestScore)
    {
        if (latestScore > 0)
        {
            //Sum the New score To The All Score Repository.
            float allScores = GetAllScore();
            allScores += latestScore;
            Save(allScoreRepo, allScores);

            //Setting the new score as Last Score.
            Save(lastScoreRepo, latestScore);

            //Check if new Score is bigger than the last high score and Set it as the new High Score.
            float highScore = GetHighScore();
            if (latestScore > highScore)
            {
                Save(highScoreRepo, latestScore);
            }
        }
    }


    public static float GetAllScore()
    {
        float allScores = 0f;
        if (PlayerPrefs.HasKey(allScoreRepo))
        {
            allScores = Retrive(allScoreRepo);
            return allScores;
        }
        else
        {
            return allScores;
        }
    }
    public static float GetLastScore()
    {
        float latestScore = 0f;
        if (PlayerPrefs.HasKey(lastScoreRepo))
        {
            latestScore = Retrive(lastScoreRepo);
            return latestScore;
        }
        else
        {
            return latestScore;
        }
    }
    public static float GetHighScore()
    {
        float highestScore = 0f;
        if (PlayerPrefs.HasKey(highScoreRepo))
        {
            highestScore = Retrive(highScoreRepo);
            return highestScore;
        }
        else
        {
            return highestScore;
        }
    }
    #endregion




    #region Private Methods
    static bool HasScore(int Count)
    {
        float scores = GetAllScore();
        if (scores >= Count)
        {
            return true;
        }
        return false;
    }



    static float Retrive(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    static void Save(string key, float val)
    {
        PlayerPrefs.SetFloat(key, val);
    }




    #endregion
}//EndClasssss/SadeQ
