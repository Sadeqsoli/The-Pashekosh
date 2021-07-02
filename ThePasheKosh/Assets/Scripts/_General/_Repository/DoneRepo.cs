using UnityEngine;

public static class DoneRepo
{


    #region Public Methods

    public static void UserHaveDoneThis(string keyRepo, bool isDone)
    {
        Debug.Log(keyRepo);
        Save(keyRepo, isDone);
    }
    public static bool HaveUserDoneThis(string keyRepo)
    {
        if (PlayerPrefs.HasKey(keyRepo))
        {
            return Retrive(keyRepo);
        }
        return false;
    }
    #endregion


    #region Private Methods

    static bool Retrive(string key)
    {
        return (PlayerPrefs.GetInt(key) == 1);
    }

    static void Save(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }
    #endregion


}//EndClassss

