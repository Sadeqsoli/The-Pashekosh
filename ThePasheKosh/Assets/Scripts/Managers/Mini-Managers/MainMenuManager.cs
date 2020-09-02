using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;
using TMPro;


public class MainMenuManager : MonoBehaviour
{
    #region Properties


    #endregion

    #region Fields
    [Header("GUI")]
    Text playername;

    #endregion

    #region Public Methods
    public void RestValues()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted!");
    }


    public void RetryConnection()
    {
        StartCoroutine(Process());
    }
    #endregion


    #region Private Methods
    void Awake()
    {
        Connectivity();
    }//Awakeee

    
    
    void SetUsername()
    {
        playername.text = UserRepo.GetUser();
    }
   
    void SignUpCheck()
    {
        if (!(PlayerPrefs.HasKey(UserRepo.RepoUser)))
        {
        }
        if (PlayerPrefs.HasKey(UserRepo.RepoUser))
        {
            SetUsername();
        }
    }








    void Connectivity()
    {
        //SignUpCheck();
        StartCoroutine(CheckConnectivity((isConnected) =>
        {
            if (isConnected)
            {
                Debug.Log("Connected");
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
            else
            {
                Debug.Log("Not Connected");
            }

        }));
    }
    IEnumerator CheckConnectivity(Action<bool> action)
    {

        UnityWebRequest www = UnityWebRequest.Get("http://google.com");
        yield return www.SendWebRequest();
        if(www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }
    IEnumerator Process()
    {
        yield return new WaitForSeconds(3f);
        HelperSceneManager.ReplayCurrentScene();
    }





    void Update()
    {
    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
