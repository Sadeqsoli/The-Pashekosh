using System.IO;
using UnityEditor;
using UnityEngine;

public class AutomatedBuild : MonoBehaviour
{


    #region Menu Items
    [MenuItem("Build/Debug/Android Debug")] 
    public static void BuildForAndroidDebugging()
    {
        GameData.CurrentBuildMode = BuildMode.debug;
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");

        string path = "../APK/0-UniversalDebug/Android";
        string apk = "/A-de-thepashekosh-" + date +".Apk";

        if (!Directory.Exists(path))
        {
            
            Directory.CreateDirectory(path);
        }
        string direct = path + apk;
        BuildPipeline.BuildPlayer( EditorBuildSettings.scenes, direct , BuildTarget.Android, BuildOptions.None).ToString();
        EditorUtility.RevealInFinder(direct);
        
    }



   [MenuItem("Build/Debug/iOS Debug")]
    public static void BuildForiOSDebugging()
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        string path = "../APK/0-UniversalDebug/iOS";
        string folder = "/iOS-de-thepashekosh" + date;
        GameData.CurrentBuildMode = BuildMode.debug;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string direct = path + folder;
        BuildPipeline.BuildPlayer( EditorBuildSettings.scenes, direct , BuildTarget.Android, BuildOptions.None).ToString();
        EditorUtility.RevealInFinder(direct);
    }



    [MenuItem("Build/Stores/Cafe Bazaar")]
    public static void BuildForCafeBazaar() 
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        string real_path = "";
        string apk = "/cb-thepashekosh" + date + ".Apk";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../APK/cafebazaar/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1="../APK/cafebazaar/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../APK/cafebazaar/release";
                    if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        string direct = real_path + apk;
        BuildPipeline.BuildPlayer( EditorBuildSettings.scenes, direct , BuildTarget.Android, BuildOptions.None).ToString();
        EditorUtility.RevealInFinder(direct);
    }



    [MenuItem("Build/Stores/Google Store")]
    public static void BuildForGoogleStore()
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        string real_path = "";
        string apk = "/gs-thepashekosh" + date + ".Apk";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../APK/googlestore/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../APK/googlestore/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../APK/googlestore/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        string direct = real_path + apk;
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, direct , BuildTarget.Android, BuildOptions.None);
        EditorUtility.RevealInFinder(direct);
    }



    [MenuItem("Build/Stores/Myket")] 
    public static void BuildForMyket() 
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        string real_path = "";
        string apk = "/mk-thepashekosh" + date + ".Apk";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../APK/myket/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../APK/myket/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../APK/myket/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        string direct = real_path + apk;
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, direct, BuildTarget.Android, BuildOptions.None);
        EditorUtility.RevealInFinder(direct);
    }



    [MenuItem("Build/Stores/IranApps")]
    public static void BuildForIranApps() 
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        string real_path = "";
        string apk = "/ia-thepashekosh" + date + ".Apk";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../APK/iranapps/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../APK/iranapps/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../APK/iranapps/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        string direct = real_path + apk;
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, direct ,BuildTarget.Android, BuildOptions.None);
        EditorUtility.RevealInFinder(direct);
    }


    [MenuItem("Build/Stores/Sib App")]
    public static void BuildForSibApp() 
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        string real_path = "";
        string folder = "/sa-thepashekosh";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../APK/sibapp/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../APK/sibapp/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../APK/sibapp/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        string direct = real_path + folder + date;
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, direct, BuildTarget.iOS, BuildOptions.None);
        EditorUtility.RevealInFinder(direct);
    }



    [MenuItem("Build/Stores/App Store")] 
    public static void BuildForAppStore() 
    {
        string date = System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss");
        string real_path = "";
        string folder = "/as-thepashekosh";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../APK/appstore/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../APK/appstore/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../APK/appstore/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        string direct = real_path + folder + date;
        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, direct, BuildTarget.iOS, BuildOptions.None);
        EditorUtility.RevealInFinder(direct);
    }

    #endregion

    #region Shared
    #endregion

    #region Helper
    #endregion
}//EndClassss/SadeQ
