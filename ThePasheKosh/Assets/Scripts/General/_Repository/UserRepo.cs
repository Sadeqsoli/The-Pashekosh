using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserRepo 
{
    #region Properties
    public static string RepoUser { get { return repoUser; } }

    #endregion

    #region Fields
    const string repoUser = "userRepo";
    const string repoPhone = "phoneRepo";
    const string repoEmail = "emailRepo";
    #endregion

    #region Public Methods
    

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
  