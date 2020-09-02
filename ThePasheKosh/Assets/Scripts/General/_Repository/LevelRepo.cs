using UnityEngine;

public static class LevelRepo
{
    #region Properties

    #endregion

    #region Fields
    const string levelRepo = "LevelRepo";

    #endregion

    #region Public Methods

    public static void PushLevel(int input)
    {
        if (input > 0)
        {
            int lastBestLevel = GetLevel();
            if(lastBestLevel < input)
            {
                //The best level that player reached.
                Save(levelRepo, input);
            }
        }
    }

    public static int GetLevel()
    {
        return Retrive(levelRepo);
    }

    #endregion




    #region Private Methods


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
