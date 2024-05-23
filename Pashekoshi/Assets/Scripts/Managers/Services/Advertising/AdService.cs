using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using UnityEngine;

namespace GameServices
{
    public class AdService : MonoBehaviour,IService/*, IUnityAdsListener*/
    {
        const string iOSGameID = "3974240";
        const string AndroidGameID = "3974241";

        const string PlacementID_NonRewarded = "video";
        const string PlacementID_Rewarded = "rewardedVideo";
        const string PlacementID_AR = "ARPlacement";
        const string PlacementID_Banner = "Banner";
        
        bool testMode = true;

        Dictionary<string, object> customEventParams = new Dictionary<string, object>();

        public void Initialize()
        {
#if UNITY_IOS || UNITY_ANDROID
            //Advertisement.AddListener(this);
            Advertisement.Initialize(AndroidGameID, testMode);
#else
            Debug.LogWarning("current platform doesn't support monetization!!!");
#endif
        } 

        public void DisplayNon_RewardedAd()
        {
            if (!Advertisement.isInitialized)
            {
                Debug.Log(PlacementID_NonRewarded + "Not Ready to Display!");
                return;
            }
            Advertisement.Show(PlacementID_NonRewarded);
        }
        public void DisplayRewardedAd()
        {
            StartCoroutine(WaitAndDisplayRewardedAd());
        }

        public void DisplayBanner_Ad()
        {
            StartCoroutine(WaitAndDisplayBanner());
        }



        IEnumerator WaitAndDisplayBanner()
        {

            yield return new WaitUntil(() => Advertisement.isInitialized);

            Advertisement.Banner.Show(PlacementID_Banner);
        }


        void MyARAdCallbackHandler(ShowResult showResult)
        {
            Debug.Log("AR ad successfully finished with result " + showResult.ToString());
            // Implement any custom logic related to returning from an AR ad.
        }

        public IEnumerator WaitAndDisplayRewardedAd()
        {

            yield return new WaitUntil(() => Advertisement.isInitialized);

            Advertisement.Show(PlacementID_Rewarded);
        }







        #region IUnityListener Methods

        public void OnUnityAdsReady(string placementId)
        {
            Debug.Log(placementId + " Ad is ready!!!");
        }

        public void OnUnityAdsDidError(string message)
        {
            Debug.Log("the Ad has Error: " + message);
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            Debug.Log(placementId + " is started!!!");
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            if (showResult == ShowResult.Finished)
            {
                // Reward the user for watching the ad to completion.
                Toast.Instance.SendToast("You'll get a reward!");
            }
            else if (showResult == ShowResult.Skipped)
            {
                // Do not reward the user for skipping the ad.
                Toast.Instance.SendToast("You don't get a reward!");
            }
            else if (showResult == ShowResult.Failed)
            {
                Toast.Instance.SendToast("The ad did not finish due to an error.");
            }
        }
        #endregion

    }//EndClassss
}
