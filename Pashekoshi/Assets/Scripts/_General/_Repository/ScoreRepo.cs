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
            //float highScore = GetHighScore();
            //if (latestScore > highScore)
            //{
            //    Save(highScoreRepo, latestScore);
            //}
        }
    }
    public static bool PushHighScore(float latestScore)
    {
        if (latestScore > 0)
        {
            float highScore = GetHighScore();
            if (latestScore > highScore)
            {
                Save(highScoreRepo, latestScore);
                return true;
            }
        }
        return false;
    }


    public static float GetAllScore()
    {
        if (!PlayerPrefs.HasKey(allScoreRepo))
        {
            return 0;
        }
        return Retrive(allScoreRepo);
    }
    public static float GetLastScore()
    {
        if (!PlayerPrefs.HasKey(lastScoreRepo))
        {
            return 0;
        }
        return Retrive(lastScoreRepo);
    }
    public static float GetHighScore()
    {
        if (!PlayerPrefs.HasKey(highScoreRepo))
        {
            return 0;
        }
        return Retrive(highScoreRepo);
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
        return PlayerPrefs.GetFloat(key);
    }
    static void Save(string key, float val)
    {
        PlayerPrefs.SetFloat(key, val);
    }




    #endregion
}//EndClasssss/SadeQ
