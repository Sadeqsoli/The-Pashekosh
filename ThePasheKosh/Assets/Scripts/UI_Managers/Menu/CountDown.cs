using UnityEngine;
using TMPro;
using System;
using System.Text;

public class CountDown : MonoBehaviour
{
    DateTime currentDate;
    DateTime oldDate;
    public float FinishTime = 1.0f;
    public TextMeshProUGUI FinishTimeText;
    public TextMeshProUGUI GoneText;
    public float GoneTime = 0.0f;
    public bool startedProcess = false;

    const string COUNTDOWNREPO = "COUNTDOWNREPOsysString";

    const int OneSecond = 1;
    const int OneMinute = 60;
    const int OneHour = 3600;
    const int OneDay = 86400;

    StringBuilder finishTimeSTR = new StringBuilder();

    void Start()
    {
        currentDate = DateTime.Now;
        if (PlayerPrefs.HasKey(COUNTDOWNREPO))
        {
            oldDate = RetriveOldDate();
        }
        else
        {
            oldDate = currentDate.AddDays(7);
        }
        TimeSpan difference = currentDate.Subtract(oldDate);
        print("Difference: " + difference);
        FinishTime -= (difference.Seconds) + (difference.Minutes * OneMinute) + (difference.Hours * OneHour) + (difference.Days * OneDay);
        GoneTime = (difference.Seconds) + (difference.Minutes * OneMinute) + (difference.Hours * OneHour) + (difference.Days * OneDay);
    }
    void StartCountDown()
    {
        print("Started");
        startedProcess = true;
    }
    void OnApplicationQuit()
    {
        SaveDateTime();
    }

    void SaveDateTime()
    {
        //Save the current system time as a string in the player prefs class
        PlayerPrefs.SetString(COUNTDOWNREPO, System.DateTime.Now.ToBinary().ToString());
        print("Saving this date to prefs: " + System.DateTime.Now);
    }

    DateTime RetriveOldDate()
    {
        long temp = Convert.ToInt64(PlayerPrefs.GetString(COUNTDOWNREPO));
        DateTime oldDate = DateTime.FromBinary(temp);
        return oldDate;
    }
    

    void Update()
    {
        GoneText.text = GoneTime.ToString();
        var timeSpan = TimeSpan.FromSeconds(FinishTime);
        if (FinishTime > OneDay)
        {
            FinishTimeText.text = finishTimeSTR.Append(timeSpan.Days).Append("D ")
                                                .Append(timeSpan.Hours).Append("H ")
                                                .Append(timeSpan.Minutes).Append("M ")
                                                .Append(timeSpan.Seconds).Append("S").ToString();
        }
        else if (FinishTime > OneHour && FinishTime < OneDay)
        {
            FinishTimeText.text = finishTimeSTR.Append(timeSpan.Hours).Append("H ")
                                                .Append(timeSpan.Minutes).Append("M ")
                                                .Append(timeSpan.Seconds).Append("S").ToString();
        }
        else if (FinishTime > OneMinute && FinishTime < OneHour)
        {
            FinishTimeText.text = finishTimeSTR.Append(timeSpan.Minutes).Append("M ")
                                                .Append(timeSpan.Seconds).Append("S").ToString();
        }
        else if (FinishTime > OneSecond && FinishTime < OneMinute)
        {
            FinishTimeText.text = finishTimeSTR.Append(timeSpan.Seconds).Append("S").ToString();
        }
        else if (FinishTime < OneSecond)
        {
            FinishTimeText.text = "Completed!";
        }
        if (startedProcess)
        {
            FinishTime = Mathf.Max(0, FinishTime - Time.deltaTime);
            if (FinishTime <= 0)
            {
                print("Finished");
                startedProcess = false;
            }
        }
    }//Updateeeee

}//EndClasss