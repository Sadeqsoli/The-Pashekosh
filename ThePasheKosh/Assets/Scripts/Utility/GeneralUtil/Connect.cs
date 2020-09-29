using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class Connect : Singleton<Connect>
{
    [SerializeField] GameObject connectionCheck;

    void Update()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            connectionCheck.SetActive(true);
            //Debug.Log("Error. Check internet connection!");
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
        {
            connectionCheck.SetActive(false);
            //Debug.Log("Good! Your Connected to your data creeier.");
        }
        else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
        {
            connectionCheck.SetActive(false);
            //Debug.Log("Perfect! Your Connected to your local area network.");
        }

    }






}//EndClasssss
