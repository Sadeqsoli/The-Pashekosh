using UnityEngine;

public static class TimeRepo
{
    #region Properties
    #endregion

    #region Fields
    const string lastTimeRepo = "LastTimeRepo";
    const string highTimeRepo = "HighTimeRepo";
    #endregion

    #region Public Methods

    public static void PushTime(float newTime)
    {
        if (newTime > 0)
        {
            //Setting the new score as Last Score.
            Save(lastTimeRepo, newTime);

            //Check if new Score is bigger than the last high score and Set it as the new High Score.
            float highScore = GetHighTime();
            if (newTime > highScore)
            {
                Save(highTimeRepo, newTime);
            }
        }
    }

    public static float GetLastTime()
    {
        return Retrive(lastTimeRepo);
    }
    public static float GetHighTime()
    {
        return Retrive(highTimeRepo);
    }
    #endregion




    #region Private Methods


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
