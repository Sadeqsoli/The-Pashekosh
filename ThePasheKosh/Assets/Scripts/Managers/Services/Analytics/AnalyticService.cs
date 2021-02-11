using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

namespace GameServices
{
    public class AnalyticService : MonoBehaviour, IService
    {
        Dictionary<string, object> customEventParams = new Dictionary<string, object>();
        public void Initialize()
        {
            Analytics.CustomEvent("gameStart");
            LevelCapReached("13233", "Jungle sasa");
            Debug.Log("Analytic Booted!!!");
        }

        void LevelCapReached(string playerID, string levelName)
        {
            customEventParams.Clear();

            customEventParams.Add("player_id", playerID);
            customEventParams.Add("level_name", levelName);
            AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelCapReached", customEventParams);
        }
        
        void HandleOnLevelStarted(int levelNumber)
        {
            Analytics.CustomEvent("levelStart", new Dictionary<string, object> { { "credits", 0 } });
        }

        void HandleOnLevelFailed(int levelNumber)
        {
            Analytics.CustomEvent("levelFailure", new Dictionary<string, object> { { "credits", 0 } });
        }

        void HandleOnLevelCompleted(int levelNumber)
        {
            Analytics.CustomEvent("levelComplete", new Dictionary<string, object> { { "credits", 0 } });
        }


    }

}//EndClasss