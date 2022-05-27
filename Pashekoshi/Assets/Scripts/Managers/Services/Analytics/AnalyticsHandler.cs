using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Analytics;

public static class AnalyticsHandler
{
    public static bool IsAnalytics_Initialized { get; private set; } = false;



    //CallCustomEvent
    public static void CCEvent(string customEventName, AEvent[] aEvents)
    {
        Dictionary<string, object> aEventDictionary = new Dictionary<string, object>();
        int aEventsLength = aEvents.Length;
        if (aEventsLength <= 0)
            return;
        for (int i = 0; i < aEventsLength; i++)
        {
            aEventDictionary.Add(aEvents[i].eName, aEvents[i].newObj);
        }
        //AnalyticsEvent
        AnalyticsResult analyticsResult = Analytics.CustomEvent(customEventName, aEventDictionary);
        GameAnalytics.NewDesignEvent(customEventName, aEventDictionary);
        Log("Multi_analyticsResult", analyticsResult);
    }
    public static void CCEvent(string customEventName, AEvent aEvent)
    {
        Dictionary<string, object> aEventDictionary = new Dictionary<string, object>();
        aEventDictionary.Add(aEvent.eName, aEvent.newObj);

        AnalyticsResult analyticsResult = Analytics.CustomEvent(customEventName, aEventDictionary);
        GameAnalytics.NewDesignEvent(customEventName, aEventDictionary);
        Log("Single_analyticsResult", analyticsResult);
    }
    public static void CCEvent(string customEventName, string eName, object newObj)
    {
        Dictionary<string, object> aEventDictionary = new Dictionary<string, object>();
        aEventDictionary.Add(eName, newObj);

        AnalyticsResult analyticsResult = Analytics.CustomEvent(customEventName, aEventDictionary);
        GameAnalytics.NewDesignEvent(customEventName, aEventDictionary);

        Log("Single_analyticsResult", analyticsResult);
    }
    public static void CCEvent(object[] customEventNames)
    {
        StringBuilder eventName = new StringBuilder();
        int eLenght = customEventNames.Length;
        for (int i = 0; i < eLenght; i++)
        {
            eventName.Append(customEventNames[i]);
        }
        AnalyticsResult analyticsResult = Analytics.CustomEvent(eventName.ToString());

        GameAnalytics.NewDesignEvent(eventName.ToString());

        Log("Wout_analyticsResult", eventName.ToString());
        Log("Wout_analyticsResult", analyticsResult);
    }
    public static void CCEvent(string customEventName)
    {
        AnalyticsResult analyticsResult = Analytics.CustomEvent(customEventName);
        GameAnalytics.NewDesignEvent(customEventName);

        Log("Wout_analyticsResult", analyticsResult);
    }

    static void RemoteConfig()
    {
        if (GameAnalytics.IsRemoteConfigsReady())
        {
            // call Remote Configs
        }
        
    }

    public static void InitializeAnalytics()
    {
        IsAnalytics_Initialized = Analytics.enabled;
        if (IsAnalytics_Initialized)
        {
            Log("IsAnalytics_Initialized", IsAnalytics_Initialized);
        }

        GameAnalytics.Initialize();

        //if (GameAnalytics.IsRemoteConfigsReady())
        //{
        //    // call Remote Configs
            
        //}
        //string value0 = GameAnalytics.GetRemoteConfigsValueAsString("reset", "resetUserPlan");
        //Debug.Log("Value: " + value0);
    }


    #region GAME ANALYTICS
   

    #endregion

    static void Log(string debugStrName, object msg)
    {
        Debug.Log(debugStrName + ": " + msg);
    }

}//EndClassssss



public class AEvent
{
    public string eName;
    public object newObj;
    public AEvent(string newEventName, object NewEventObject)
    {
        eName = newEventName;
        newObj = NewEventObject;
    }
}