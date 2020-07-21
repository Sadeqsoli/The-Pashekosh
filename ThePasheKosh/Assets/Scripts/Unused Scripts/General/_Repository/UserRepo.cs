using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRepo : MonoBehaviour
{
    #region Properties
    public string RepoUser { get { return repoUser; } }

    #endregion

    #region Fields
    const string repoUser = "userRepo";
    const string repoPhone = "phoneRepo";
    const string repoEmail = "emailRepo";
    const string repoAuth = "Authrepo";
    const string repoRefreshAuth = "RefreshAuthrpo";

    string username;
    string phone;
    string email;
    string authToken;
    string refreshAuthToken;
    #endregion

    #region Public Methods
    

    public void PushUsername(string newUser)
    {
        Save(repoUser, newUser);
    }
    public void PushPhone(string newPhone)
    {
        Save(repoPhone, newPhone);
    }
    public void PushEmail(string newEmail)
    {
        Save(repoEmail, newEmail);
    }
    public void PushAuth(string newAuth)
    {
        Save(repoAuth, newAuth);
    }
    public void PushRefreshAuth(string newRefreshAuth)
    {;
        Save(repoRefreshAuth, newRefreshAuth);
    }
   

    public string GetUser()
    {
        return Retrive(repoUser);
    }
    public string GetPhone()
    {
        return Retrive(repoPhone);
    }
    public string GetEmail()
    {
        return Retrive(repoEmail);
    }
    public string GetAuth()
    {
        return Retrive(repoAuth);
    }
    public string GetRefreshAuth()
    {
        return Retrive(repoRefreshAuth);
    }
  
    #endregion




    #region Private Methods
    void Start()
    {
        username = Retrive(repoUser);
        phone = Retrive(repoPhone);
        email = Retrive(repoEmail);
        authToken = Retrive(repoAuth);
        refreshAuthToken = Retrive(repoRefreshAuth);
    }//Starttttt





    private string Retrive(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    private void Save(string key, string val)
    {
        PlayerPrefs.SetString(key, val);
    }





    void Update()
    {

    }//Updateeeee

    #endregion

}//EndClasssss/SadeQ
  