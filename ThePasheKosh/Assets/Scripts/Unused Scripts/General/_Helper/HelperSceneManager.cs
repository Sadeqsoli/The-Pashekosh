using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class HelperSceneManager
{
    static int TapCount = 0;
    static float NewTime;
    static float MaxDubbleTapTime = 0.3f;
    public static void GetBackByEscapeButton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GoToNextOrPrevScene(false);
            }
        }
    }

    public static void GoToNextOrPrevScene(bool isGoingNext)
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        int buildNumber;
        if (isGoingNext)
        {
            buildNumber = buildIndex + 1;
        }
        else
        {
            buildNumber = buildIndex - 1;
        }
        SceneManager.LoadScene(buildNumber);
    }
    public static void GoToAnotherScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    public static void ReplayCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public static void QuitByEscapeButton()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TapCount += 1;
                if (TapCount == 1)
                {
                    NewTime = Time.time + MaxDubbleTapTime;

                }
                else if (TapCount == 2 && Time.time <= NewTime)
                {
                    // Quit the application
                    Application.Quit(0);
                }
            }
        }
    }



}//EndCalssss/SadeQ

//This is A Line of code for using back Button in android to get back in by build index.

//AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
//activity.Call<bool>("moveTaskToBack", true);