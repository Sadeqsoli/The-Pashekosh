using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PillRepo
{
    #region Properties
    public static string RepoName { get { return pillRepo; } }
    #endregion

    #region Fields
    const string pillRepo = "kelidRepo";
    static int kelid;
    #endregion

    #region Public Methods
    public static void PushPill(int count)
    {
        if (count > 0)
        {
            kelid = kelid + count;
            SaveRepo();
        }
    }
    public static bool PopPill(int count)
    {
        if (count > 0)
        {
            if (HasPill(count))
            {
                kelid = kelid - count;
                SaveRepo();
                return true;
            }
        }
        return false;
    }

    public static int GetPill()
    {
        return Retrive();
    }


    #endregion

    #region Private Methods





    static bool HasPill(int Count)
    {
        if (kelid >= Count)
        {
            return true;
        }
        return false;
    }
    static int Retrive()
    {
        return PlayerPrefs.GetInt(pillRepo);
    }
    static void SaveRepo()
    {
        PlayerPrefs.SetInt(pillRepo, kelid);
    }

    #endregion
}//EndClasssss/SadeQ
