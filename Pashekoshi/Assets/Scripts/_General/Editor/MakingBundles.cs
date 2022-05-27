using UnityEngine;
using System.IO;
using UnityEditor;

public class MakingBundles : MonoBehaviour
{
    #region public Variables

    #endregion

    #region Private Variables
 
    #endregion

    #region Public Methods
    #endregion


    #region Private Methods
    void Start()
    {

    }//Startttttt


    [MenuItem("Build Bundle/Bundle for Win")]
    static void BuildAllAssetBundlesWin()
    {
        string assetBundleDirectory = "../Assetbundles/Win";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
        EditorUtility.RevealInFinder(assetBundleDirectory);
    }

    [MenuItem("Build Bundle/Bundle for Android")]
    static void BuildAllAssetBundlesAndroid()
    {
        string assetBundleDirectory = "../Assetbundles/Android";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
        EditorUtility.RevealInFinder(assetBundleDirectory);
    }


    [MenuItem("Build Bundle/Bundle for iOS")]
    static void BuildAllAssetBundlesIos()
    {
        string assetBundleDirectory = "../Assetbundles/iOS";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.iOS);
        EditorUtility.RevealInFinder(assetBundleDirectory);
    }


    #endregion
}//EndClasssss

