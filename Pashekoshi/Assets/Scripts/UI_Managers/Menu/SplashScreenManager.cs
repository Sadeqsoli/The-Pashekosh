using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum AssetType { Music, SFXs, Background }
public class SplashScreenManager : MonoBehaviour
{
    [SerializeField] GameObject HouseFly;
    Canvas canvas;

    void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        canvas.worldCamera = CamTrack.Instance.GetComponent<Camera>();
        GoToMainMenu();
    }
    void Start()
    {
        SFXPlayer.Instance.PlaySFX(IdentitySound.PashekoshLogo);
    }
    void TurnOnFly()
    {
        HouseFly.SetActive(true);
    }
    void SplashIsDone()
    {
        HouseFly.SetActive(false);
        gameObject.transform.Scaler(TTScale.ScaleDown);
    }

    void GoToMainMenu()
    {
        if (TargetManager.isSplashed)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            TargetManager.isSplashed = true;
        }
    }


    void PlaySloppy()
    {
        SFXPlayer.Instance.PlaySFX(IdentitySound.SloppyStudioLogo);
    }



}//EndClasssss

