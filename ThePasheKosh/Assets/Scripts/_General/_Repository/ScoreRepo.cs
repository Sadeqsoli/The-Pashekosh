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
    #endregion

    #region Public Methods

    public static void PushScore(float newScore)
    {
        if (newScore > 0)
        {
            //Sum the New score To The All Score Repository.
            float scores = GetAllScore();
            scores += newScore;
            Save(allScoreRepo, scores);

            //Setting the new score as Last Score.
            Save(lastScoreRepo, newScore);

            //Check if new Score is bigger than the last high score and Set it as the new High Score.
            float highScore = GetHighScore();
            if (newScore > highScore)
            {
                Save(highScoreRepo, newScore);
            }
        }
    }


    public static float GetAllScore()
    {
        return Retrive(allScoreRepo);
    }
    public static float GetLastScore()
    {
        return Retrive(lastScoreRepo);
    }
    public static float GetHighScore()
    {
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
        return PlayerPrefs.GetInt(key);
    }
    static void Save(string key, float val)
    {
        PlayerPrefs.SetFloat(key, val);
    }




    #endregion
}//EndClasssss/SadeQ
