using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public static class HelperAssetBundleHandler
{
  

    private static AssetBundle GetLocalAssetBundle(MonoBehaviour cor,  string BundleFileName)
    {
     AssetBundle  LoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, BundleFileName));
        if (LoadedAssetBundle == null)
        {

            Debug.Log("Failed to load AssetBundle localy! well go for downloading");
            cor.StartCoroutine(DownloadAssetBundle(BundleFileName, (AssetBundle)=> {
                LoadedAssetBundle = AssetBundle;
            } ));
            return LoadedAssetBundle;
        }
        else 
        {
            return LoadedAssetBundle;
        }
    }



    private static IEnumerator DownloadAssetBundle(string bundleName, Action<AssetBundle> ReturnBundle)
    {
        string url = ""; 
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                url = GameURLs.BaseBundleUrl.debug + "/" + GameData.CurrentPlatform.ToString() + "/" + bundleName;
                break;
            case BuildMode.openBeta:
                url = GameURLs.BaseBundleUrl.openBeta + "/" + GameData.CurrentPlatform.ToString() + "/" + bundleName;
                break;
            case BuildMode.release:
                url = GameURLs.BaseBundleUrl.release + "/" + GameData.CurrentPlatform.ToString() + "/" + bundleName;
                break;
        }

        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url, 0);
        yield return request.SendWebRequest();
        AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
       
    }




}//EndClasss/SadeQ
