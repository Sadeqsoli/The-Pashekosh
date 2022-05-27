using System;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class AutomatedBuild : MonoBehaviour
{
    [MenuItem("Build/Debug/Android")] 
    public static void BuildForAndroidDebugging()
    {
        string path = "../Export/0-UniversalDebug/Android";
        StringBuilder androidDebugAddress = new StringBuilder();
        androidDebugAddress.Append(path).Append("/A-de-pk-").Append("[").Append(DB.VC.dbVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm")).Append(".apk");

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildPlayer( EditorBuildSettings.scenes, androidDebugAddress.ToString(),
            BuildTarget.Android, BuildOptions.None).ToString();

        EditorUtility.RevealInFinder(androidDebugAddress.ToString());
        
    }

   [MenuItem("Build/Debug/iOS")]
    public static void BuildForiOSDebugging()
    {

        string path = "../Export/0-UniversalDebug/iOS";
        StringBuilder iOSDebugAddress = new StringBuilder();
        iOSDebugAddress.Append(path).Append("/iOS-de-pk-")
            .Append(DateTime.Now.ToString("yyyy-MM-dd-hh-mm"));

        GameData.CurrentBuildMode = BuildMode.debug;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildPlayer( EditorBuildSettings.scenes, iOSDebugAddress.ToString(), BuildTarget.iOS, BuildOptions.None).ToString();
        EditorUtility.RevealInFinder(iOSDebugAddress.ToString());
    }

   [MenuItem("Build/Debug/WGL")]
    public static void BuildForWebGLDebugging()
    {

        string path = "../Export/0-UniversalDebug/WGL";
        StringBuilder webGLDebugAddress = new StringBuilder();
        webGLDebugAddress.Append(path).Append("/WGL-de-pk-")
            .Append(DateTime.Now.ToString("yyyy-MM-dd-hh-mm"));

        GameData.CurrentBuildMode = BuildMode.debug;
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        BuildPipeline.BuildPlayer( EditorBuildSettings.scenes, webGLDebugAddress.ToString(), BuildTarget.WebGL, BuildOptions.None).ToString();
        EditorUtility.RevealInFinder(webGLDebugAddress.ToString());
    }




    [MenuItem("Build/Stores/Myket")]
    public static void BuildForMyket()
    {
        string real_path = "";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../Export/myket/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../Export/myket/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../Export/myket/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }

        StringBuilder androidDebugAddress = new StringBuilder();
        androidDebugAddress.Append(real_path).Append("/mk-pk-").Append("[").Append(DB.VC.mkVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm")).Append(".apk");

        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, androidDebugAddress.ToString()
            , BuildTarget.Android, BuildOptions.None);
        EditorUtility.RevealInFinder(androidDebugAddress.ToString());
    }

    [MenuItem("Build/Stores/Cafe Bazaar")]
    public static void BuildForCafeBazaar() 
    {
        string real_path = "";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../Export/cafebazaar/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1= "../Export/cafebazaar/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../Export/cafebazaar/release";
                    if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        StringBuilder androidDebugAddress = new StringBuilder();
        androidDebugAddress.Append(real_path).Append("/cb-pk-").Append("[").Append(DB.VC.cbVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm")).Append(".apk");

        BuildPipeline.BuildPlayer( EditorBuildSettings.scenes, androidDebugAddress.ToString()
            , BuildTarget.Android, BuildOptions.None).ToString();
        EditorUtility.RevealInFinder(androidDebugAddress.ToString());
    }

    [MenuItem("Build/Stores/Zarinpal")]
    public static void BuildForZarinpal()
    {
        string real_path = "";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../Export/zarinpal/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../Export/zarinpal/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../Export/zarinpal/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }

        StringBuilder zarinpalDebugAddress = new StringBuilder();
        zarinpalDebugAddress.Append(real_path).Append("/zp-pk-").Append("[").Append(DB.VC.dbVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm")).Append(".apk");


        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, zarinpalDebugAddress.ToString(), BuildTarget.Android, BuildOptions.None);
        EditorUtility.RevealInFinder(zarinpalDebugAddress.ToString());
    }

    [MenuItem("Build/Stores/Google Store")]
    public static void BuildForGoogleStore()
    {
        string real_path = "";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../Export/googlestore/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../Export/googlestore/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../Export/googlestore/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }

        StringBuilder androidDebugAddress = new StringBuilder();
        androidDebugAddress.Append(real_path).Append("/gs-pk-").Append("[").Append(DB.VC.gsVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm")).Append(".apk");

        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, androidDebugAddress.ToString(), BuildTarget.Android, BuildOptions.None);
        EditorUtility.RevealInFinder(androidDebugAddress.ToString());
    }


    [MenuItem("Build/Stores/IranApps")]
    public static void BuildForIranApps() 
    {
        string real_path = "";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../Export/iranapps/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../Export/iranapps/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../Export/iranapps/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }

        StringBuilder androidDebugAddress = new StringBuilder();
        androidDebugAddress.Append(real_path).Append("/ia-pk-").Append("[").Append(DB.VC.iaVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm")).Append(".apk");

        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, androidDebugAddress.ToString()
            , BuildTarget.Android, BuildOptions.None);
        EditorUtility.RevealInFinder(androidDebugAddress.ToString());
    }


    [MenuItem("Build/Stores/Sib App")]
    public static void BuildForSibApp() 
    {
        string real_path = "";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../Export/sibapp/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../Export/sibapp/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../Export/sibapp/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }

        StringBuilder iOSDebugAddress = new StringBuilder();
        iOSDebugAddress.Append(real_path).Append("/sa-pk-").Append("[").Append(DB.VC.saVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm"));

        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, iOSDebugAddress.ToString()
            , BuildTarget.iOS, BuildOptions.None);
        EditorUtility.RevealInFinder(iOSDebugAddress.ToString());
    }



    [MenuItem("Build/Stores/App Store")] 
    public static void BuildForAppStore() 
    {
        string real_path = "";
        switch (GameData.CurrentBuildMode)
        {
            case BuildMode.debug:
                string path = "../Export/appstore/debug";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                real_path = path;
                break;

            case BuildMode.openBeta:
                string path1 = "../Export/appstore/openBeta";
                if (!Directory.Exists(path1))
                {
                    Directory.CreateDirectory(path1);
                }
                real_path = path1;
                break;

            case BuildMode.release:
                string path2 = "../Export/appstore/release";
                if (!Directory.Exists(path2))
                {
                    Directory.CreateDirectory(path2);
                }
                real_path = path2;
                break;
        }
        StringBuilder iOSDebugAddress = new StringBuilder();
        iOSDebugAddress.Append(real_path).Append("/as-pk-").Append("[").Append(DB.VC.asVersion)
            .Append("]").Append(DateTime.Now.ToString("-yyyy-MM-dd-hh-mm"));

        BuildPipeline.BuildPlayer(EditorBuildSettings.scenes, iOSDebugAddress.ToString()
            , BuildTarget.iOS, BuildOptions.None);
        EditorUtility.RevealInFinder(iOSDebugAddress.ToString());
    }


}//EndClassss
