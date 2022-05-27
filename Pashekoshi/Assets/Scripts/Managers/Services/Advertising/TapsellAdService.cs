using System.Collections;
using System.Collections.Generic;
using TapsellPlusSDK;
using UnityEngine;

public enum AdType { RewardedVid, Interstitial, NativeBanner, StandardBanner }
public class TapsellAdService : Singleton<TapsellAdService>
{
    readonly string TAPSELLPLUS_KEY = "";
    readonly string ZONE_ID = "";
    readonly string ZoneID = "";
    readonly int BANNER_TYPE = 0;
    readonly int HORIZONTAL_GRAVITY = 0;
    readonly int VERTICAL_GRAVITY = 0;
    string _responseId = "";

    public void Request(AdType adType)
    {
        switch (adType)
        {
            case AdType.RewardedVid:
                TapsellPlus.RequestRewardedVideoAd(ZONE_ID,

                  tapsellPlusAdModel =>
                  {
                      Debug.Log("on response " + tapsellPlusAdModel.responseId);
                      _responseId = tapsellPlusAdModel.responseId;
                  },
                  error =>
                  {
                      Debug.Log("Error " + error.message);
                  }
              );
                break;
            case AdType.Interstitial:
                TapsellPlus.RequestInterstitialAd(ZONE_ID,

                  tapsellPlusAdModel =>
                  {
                      Debug.Log("on response " + tapsellPlusAdModel.responseId);
                      _responseId = tapsellPlusAdModel.responseId;
                  },
                  error =>
                  {
                      Debug.Log("Error " + error.message);
                  }
              );
                break;
            case AdType.NativeBanner:
                TapsellPlus.RequestNativeBannerAd(ZoneID,

           tapsellPlusAdModel =>
           {
               Debug.Log("On Response " + tapsellPlusAdModel.responseId);
               _responseId = tapsellPlusAdModel.responseId;
           },
           error =>
           {
               Debug.Log("Error " + error.message);
           }
       );
                break;
            case AdType.StandardBanner:
                TapsellPlus.RequestStandardBannerAd(ZoneID, BANNER_TYPE,
            tapsellPlusAdModel =>
            {
                Debug.Log("on response " + tapsellPlusAdModel.responseId);
                _responseId = tapsellPlusAdModel.responseId;
            },
            error =>
            {
                Debug.Log("Error " + error.message);
            }
        );
                break;
        }

    }

    public void Show(AdType adType)
    {
        switch (adType)
        {
            case AdType.RewardedVid:
                TapsellPlus.ShowRewardedVideoAd(_responseId,

                  tapsellPlusAdModel =>
                  {
                      Debug.Log("onOpenAd " + tapsellPlusAdModel.zoneId);
                  },
                  tapsellPlusAdModel =>
                  {
                      Debug.Log("onReward " + tapsellPlusAdModel.zoneId);
                  },
                  tapsellPlusAdModel =>
                  {
                      Debug.Log("onCloseAd " + tapsellPlusAdModel.zoneId);
                  },
                  error =>
                  {
                      Debug.Log("onError " + error.errorMessage);
                  }
              );
                break;
            case AdType.Interstitial:
                TapsellPlus.ShowInterstitialAd(_responseId,

                  tapsellPlusAdModel =>
                  {
                      Debug.Log("onOpenAd " + tapsellPlusAdModel.zoneId);
                  },
                  tapsellPlusAdModel =>
                  {
                      Debug.Log("onCloseAd " + tapsellPlusAdModel.zoneId);
                  },
                  error =>
                  {
                      Debug.Log("onError " + error.errorMessage);
                  }
              );
                break;
            case AdType.NativeBanner:
                TapsellPlus.ShowNativeBannerAd(_responseId, this,

           tapsellPlusNativeBannerAd =>
           {
               Debug.Log("onOpenAd " + tapsellPlusNativeBannerAd.zoneId);
               //adHeadline.text = ArabicSupport.ArabicFixer.Fix(tapsellPlusNativeBannerAd.title);
               //adCallToAction.text = ArabicSupport.ArabicFixer.Fix(tapsellPlusNativeBannerAd.callToActionText);
               //adBody.text = ArabicSupport.ArabicFixer.Fix(tapsellPlusNativeBannerAd.description);
               //adImage.texture = tapsellPlusNativeBannerAd.landscapeBannerImage;

               //tapsellPlusNativeBannerAd.RegisterImageGameObject(adImage.gameObject);
               //tapsellPlusNativeBannerAd.RegisterHeadlineTextGameObject(adHeadline.gameObject);
               //tapsellPlusNativeBannerAd.RegisterCallToActionGameObject(adCallToAction.gameObject);
               //tapsellPlusNativeBannerAd.RegisterBodyTextGameObject(adBody.gameObject);
           },
           error =>
           {
               Debug.Log("onError " + error.errorMessage);
           }
       );
                break;
            case AdType.StandardBanner:
                TapsellPlus.ShowStandardBannerAd(_responseId, HORIZONTAL_GRAVITY, VERTICAL_GRAVITY,

            tapsellPlusAdModel =>
            {
                Debug.Log("onOpenAd " + tapsellPlusAdModel.zoneId);
            },
            error =>
            {
                Debug.Log("onError " + error.errorMessage);
            }
        );
                break;
        }

        
        

        
        

    }

    public void ShowHide(int standardBanner)
    {
        switch(standardBanner)
        {
            case 0:
                TapsellPlus.HideStandardBannerAd();
                break;
            case 1:
                //TapsellPlus.TapsellPlus.DisplayStandardBannerAd();

                break;
            case 2:
                TapsellPlus.DestroyStandardBannerAd(_responseId);
                break;
        }
    }

    void Start()
    {
        TapsellPlus.Initialize(TAPSELLPLUS_KEY,
             adNetworkName => Debug.Log(adNetworkName + " Initialized Successfully."),
             error => Debug.Log(error.ToString()));
        TapsellPlus.SetGdprConsent(true);
    }


}//EndClassss
