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
    [Header("Game Objects")]
    public GameObject noConnectionPnl;
    public GameObject bgConnection;
    public GameObject process;
    public GameObject signupPnl;
    

    [Header("GUI")]
    public Text playername;
    public TextMeshProUGUI percentageTXT;

    #endregion

    #region Fields
    [Header("Scripts")]
    [SerializeField] UserRepo userRepo = null;
    #endregion

    #region Public Methods
    public void SceneController(bool isGoingNext)
    {
        HelperSceneManager.GoToNextOrPrevScene(isGoingNext);
    }
    public void GoTOAnotherScene(int buildIndex)
    {
        HelperSceneManager.GoToAnotherScene(buildIndex);
    }
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

    
    
    private void SetUsername()
    {
        playername.text = userRepo.GetUser();
    }
   
    private void SignUpCheck()
    {
        if (!(PlayerPrefs.HasKey(userRepo.RepoUser)))
        {
            signupPnl.SetActive(true);
        }
        if (PlayerPrefs.HasKey(userRepo.RepoUser))
        {
            signupPnl.SetActive(false);
            SetUsername();
        }
    }

    private void Connectivity()
    {
        noConnectionPnl.SetActive(false);
        //SignUpCheck();
        percentageTXT.text = BatteryChecker.CurrentPercent().ToString();
        StartCoroutine(CheckConnectivity((isConnected) =>
        {
            if (isConnected)
            {
                Debug.Log("Connected");
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
            else
            {
                noConnectionPnl.SetActive(true);
                Debug.Log("Not Connected");
            }

        }));
    }
    private IEnumerator CheckConnectivity(Action<bool> action)
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
    private IEnumerator Process()
    {
        bgConnection.SetActive(false);
        process.SetActive(true);
        yield return new WaitForSeconds(3f);
        HelperSceneManager.ReplayCurrentScene();
    }





    void Update()
    {
    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
