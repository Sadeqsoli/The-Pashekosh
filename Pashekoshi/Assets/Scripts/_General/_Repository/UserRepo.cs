using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserRepo
{
    #region Properties
    public static string RepoUserSignup { get { return repoUserSignup; } }

    #endregion

    #region Fields
    const string repoUserSignup = "userRepoSignup";
    const string repoUserCycle = "userCycleRepo";
    const string repoUser = "userRepo";
    const string repoPhone = "phoneRepo";
    const string repoEmail = "emailRepo";
    #endregion

    #region Public Methods

    public static void SetUserSignedIn(bool isTrue)
    {
        PlayerPrefs2.SetBool(repoUserSignup, isTrue);
    }
    public static void PushUsername(string newUser)
    {
        Save(repoUser, newUser);
    }
    public static void PushPhone(string newPhone)
    {
        Save(repoPhone, newPhone);
    }
    public static void PushEmail(string newEmail)
    {
        Save(repoEmail, newEmail);
    }

    public static void AddUserCycleNumber()
    {
        int newCycleNumber = RetriveINT(repoUserCycle) + 1;
        SaveINT(repoUserCycle, newCycleNumber);
    }
    public static int GetPushUserCycleNumber()
    {
       return RetriveINT(repoUserCycle);
    }



    public static bool IsUserSignedIn()
    {
        return PlayerPrefs2.GetBool(repoUserSignup);
    }
    public static string GetUser()
    {
        return Retrive(repoUser);
    }
    public static string GetPhone()
    {
        return Retrive(repoPhone);
    }
    public static string GetEmail()
    {
        return Retrive(repoEmail);
    }


    #endregion




    #region Private Methods

    static int RetriveINT(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    static void SaveINT(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
    }
    static string Retrive(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    static void Save(string key, string val)
    {
        PlayerPrefs.SetString(key, val);
    }



    #endregion

}//EndClasssss/SadeQ
