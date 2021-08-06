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


    //void DownloadingAll()
    //{
    //    //TODO: Pull Up loading bar.
    //    DownloadingAssets(DB.ServerBackgroundDIR(), AssetType.Background);
    //    DownloadingAssets(DB.ServerMusicsDIR(), AssetType.Music);
    //    DownloadingAssets(DB.ServerSFXsDIR(), AssetType.SFXs);
    //}

    //void DownloadingAssets(string dirURL, AssetType assetType)
    //{
    //    DirectoryInfo dir = new DirectoryInfo(dirURL);
    //    FileInfo[] fileInfo = dir.GetFiles("*.*");
    //    foreach (FileInfo file in fileInfo)
    //    {
    //        if (assetType == AssetType.Background)
    //            NetCenter.Instance.DownloadFileToDisk(DB.ServerBackPath(file.Name), DB.LocalBackPath(file.Name));
    //        else if (assetType == AssetType.Music)
    //            NetCenter.Instance.DownloadFileToDisk(DB.ServerMusics(file.Name), DB.LocalMusics(file.Name));
    //        else if (assetType == AssetType.SFXs)
    //            NetCenter.Instance.DownloadFileToDisk(DB.ServerSFXs(file.Name), DB.LocalSFXs(file.Name));
    //    }
    //}



}//EndClasssss

