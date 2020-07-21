using UnityEngine;
using System;

public class MobileNotificationManager : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    private const string gameTitle = "appName";
    private const string sIcon = "app_icon_small";
    private const string lIcon = "app_icon_large";

    private string notifBody = "You've Left your App 1 minutes ago, try this new thing that we consider fun for for you!";
    private string gameStatus = "Opened from 1 Minutes Notification";
    //public Text txtGameStatus;
    #endregion

    #region Public Methods


    #endregion


    #region Private Methods
    void Start()
    {
        NotificationCenter.InitializeCheck();
        //txtGameStatus.text = NotificationCenter.PushingCustomDataNotification();

    }//Startttttt



    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
        {
            PushNotification(new TimeSpan(0, 0, 1, 0));
        }
        else
        {
            NotificationCenter.InitializeCheck();
        }
    }

    private void PushNotification(TimeSpan timeSpan)
    {
        if (timeSpan.Days > 0 || timeSpan.Hours > 0 || timeSpan.Minutes > 0 || timeSpan.Seconds > 0)
        {
            NotificationCenter.SendNotification(gameTitle, notifBody, timeSpan, sIcon, lIcon, gameStatus);
        }
    }



    void Update()
    {


    }//Updateeeee
    #endregion
}//EndClasssss/SadeQ
