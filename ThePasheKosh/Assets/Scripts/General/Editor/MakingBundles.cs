using System.IO;
using UnityEditor;


public class MakingBundles 
{
    #region Properties

    #endregion

    #region Fields
 
    #endregion

    #region Public Methods
    #endregion


    #region Private Methods

    [MenuItem("Build Bundle/Bundle for Win")]
    public static void BuildAllAssetBundlesWin()
    {
        string assetBundleDirectory = "../Assetbundles/Win";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }

    [MenuItem("Build Bundle/Bundle for Android")]
    public static void BuildAllAssetBundlesAndroid()
    {
        string assetBundleDirectory = "../Assetbundles/Android";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.Android);
    }


    [MenuItem("Build Bundle/Bundle for iOS")]
    public static void BuildAllAssetBundlesIos()
    {
        string assetBundleDirectory = "../Assetbundles/iOS";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.iOS);
    }

    #endregion
}//EndClassss/SadeQ

