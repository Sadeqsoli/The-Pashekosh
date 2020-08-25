using UnityEngine;
using UnityEditor;
public class AutomatedPrepare
{
    private static string cbVersion = "1.0.0"; private static int cbVersionCode = 1;
    private static string gsVersion = "1.0.0"; private static int gsVersionCode = 1;
    private static string mkVersion = "1.0.0"; private static int mkVersionCode = 1;
    private static string iaVersion = "1.0.0"; private static int iaVersionCode = 1;
    private static string saVersion = "1.0.0";
    private static string asVersion = "1.0.0";


    #region menu items
    [MenuItem("Build/Build Mode/Debug Build")]
    public static void DebugBuild() { GameData.CurrentBuildMode = BuildMode.debug; }
    [MenuItem("Build/Build Mode/Open Beta Build")]
    public static void OpenBetaBuild() { GameData.CurrentBuildMode = BuildMode.openBeta; }
    [MenuItem("Build/Build Mode/Release Build")]
    public static void ReleaseBuild() { GameData.CurrentBuildMode = BuildMode.release; }


    [MenuItem("Build/Debug/Switch For Android Debugging")]
    public static void PrepareForAndroidDebugging()
    {
        GameData.CurrentBuildMode = BuildMode.debug;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.sloppy.a.de.thepashekosh");
        SwitchPlatform(BuildTargetGroup.Android, BuildTarget.Android);
        SetSpecificAndroid();
    }


    [MenuItem("Build/Debug/Switch For iOS Debugging")]
    public static void PrepareForiOSDebugging()
    {
        GameData.CurrentBuildMode = BuildMode.debug;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, "com.sloppy.iOS.de.thepashekosh");
        SwitchPlatform(BuildTargetGroup.iOS, BuildTarget.iOS);
        SetSpecificiOS();
    }






    [MenuItem("Build/Prepare For Build/Cafe Bazaar")]
    public static void PrepareForCafeBazaar()
    {
        PlayerSettings.bundleVersion = cbVersion;
        PlayerSettings.Android.bundleVersionCode = cbVersionCode;
        GameData.CurrentStoreForBuild = Store.CafeBazaar;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.sloppy.cb.thepashekosh");
        SwitchPlatform(BuildTargetGroup.Android, BuildTarget.Android);
        SetSpecificAndroid();
    }

    [MenuItem("Build/Prepare For Build/Google Store")]
    public static void PrepareForGoogleStore()
    {
        PlayerSettings.bundleVersion = gsVersion;
        PlayerSettings.Android.bundleVersionCode = gsVersionCode;
        GameData.CurrentStoreForBuild = Store.GoogleStore;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.sloppy.gs.thepashekosh");
        SwitchPlatform(BuildTargetGroup.Android, BuildTarget.Android);
        SetSpecificAndroid();
    }

    [MenuItem("Build/Prepare For Build/Myket")]
    public static void PrepareForMyket()
    {
        PlayerSettings.bundleVersion = mkVersion;
        PlayerSettings.Android.bundleVersionCode = mkVersionCode;
        GameData.CurrentStoreForBuild = Store.Myket;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.sloppy.mk.thepashekosh");
        SwitchPlatform(BuildTargetGroup.Android, BuildTarget.Android);
        SetSpecificAndroid();
    }

    [MenuItem("Build/Prepare For Build/IranApps")]
    public static void PrepareForIranApps()
    {
        PlayerSettings.bundleVersion = iaVersion;
        PlayerSettings.Android.bundleVersionCode = iaVersionCode;
        GameData.CurrentStoreForBuild = Store.IranApps;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.Android, "com.sloppy.ia.thepashekosh");
        SwitchPlatform(BuildTargetGroup.Android, BuildTarget.Android);
        SetSpecificAndroid();
    }

    [MenuItem("Build/Prepare For Build/Sib App")]
    public static void PrepareForSibApp()
    {
        PlayerSettings.bundleVersion = saVersion;
        GameData.CurrentStoreForBuild = Store.SibApp;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, "com.sloppy.sa.thepashekosh");
        SwitchPlatform(BuildTargetGroup.iOS, BuildTarget.iOS);
        SetSpecificiOS();
    }

    [MenuItem("Build/Prepare For Build/App Store")]
    public static void PrepareForAppStore()
    {
        PlayerSettings.bundleVersion = asVersion;
        GameData.CurrentStoreForBuild = Store.AppleStore;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.iOS, "com.sloppy.as.thepashekosh");
        SwitchPlatform(BuildTargetGroup.iOS, BuildTarget.iOS);
        SetSpecificiOS();
    }

    #endregion




    #region Shared
    public static void SwitchPlatform(BuildTargetGroup targetGroup, BuildTarget target)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(targetGroup, target);
    }

    static void SetAllowedOrientations()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
    }

    //TODO: Set icone in a right path and us it in right time.
    static void SetAppIcon(string iconName, BuildTargetGroup targetGroup)
    {
        // icon name is address like this: assets/ddd/xxxx.jpg
        Texture2D icon = Resources.Load(iconName) as Texture2D;
        Texture2D[] icons = new Texture2D[] { icon, icon, icon, icon };
        PlayerSettings.SetIconsForTargetGroup(targetGroup, icons);

    }


    static void SetSpecificAndroid()
    {
        //todo update all of these in right time
        GameData.CurrentPlatform = Platform.android;
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel19;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevelAuto;
        PlayerSettings.Android.useCustomKeystore = true;
        PlayerSettings.Android.keystoreName = @"D:/OUTPUT/test.keystore"; //keystore path and name.
        PlayerSettings.Android.keystorePass = "tes342323";// keystore password
        PlayerSettings.Android.keyaliasName = "test";
        PlayerSettings.Android.keyaliasPass = "test323231";
        SetScreenHorizontalOrientation();
    }
    static void SetSpecificiOS()
    {
        GameData.CurrentPlatform = Platform.ios;
        PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;
        SetScreenHorizontalOrientation();
    }

    static void SetScreenHorizontalOrientation()
    {
        Screen.autorotateToPortrait = false;
        Screen.autorotateToPortraitUpsideDown = false;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    static void SetScreenVerticalOrientation()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }



    #endregion

}//EndClassss/SadeQ
