using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text;

public class AutomatedPrepare : MonoBehaviour
{

    readonly static string bundleIdentifier = "com.sloppystudio.pashekoshi";

    readonly static string keystoreAddress = @"..\AndroidKeystore\PashekoshiKS.keystore";
    readonly static string keystorePass = "C&hqS!*w3z=j?gEY!ARJQgLB8MgcCqaMj%@uhfh5X-7xR%qv9sU7aQY7MrhstLwP";

    readonly static string keyAliasAddress = "Pashekoshialias";
    readonly static string keyAliasPass = "p5-ZkKr45%a54WAd7&Hue5dZ8pz%X@vu8Dt%$hKcejEYg!5K6HW?+?f5zv?9Kvwu";


    public static string androidManifestInProject { get { return @"Assets\Plugins\Android\AndroidManifest.xml"; } }

    #region menu items
    [MenuItem("Build/Build Mode/Debug Build")]
    public static void DebugBuild() { GameData.CurrentBuildMode = BuildMode.debug; }
    [MenuItem("Build/Build Mode/Open Beta Build")]
    public static void OpenBetaBuild() { GameData.CurrentBuildMode = BuildMode.openBeta; }
    [MenuItem("Build/Build Mode/Release Build")]
    public static void ReleaseBuild() { GameData.CurrentBuildMode = BuildMode.release; }


    [MenuItem("Switch/Debug/Android")]
    public static void PrepareForAndroidDebugging()
    {
        ////Deleting Bazaar file 
        //if (File.Exists(JarFile.CafeBazaarIn))
        //    File.Delete(JarFile.CafeBazaarIn);

        ////Deleting Myket file 
        //if (File.Exists(JarFile.MyketIn))
        //    File.Delete(JarFile.MyketIn);

        ////Copy Manifest file from out into the plugins/android project instead of Myket or bazaar
        //byte[] manifestFileInBytes = File.ReadAllBytes(Manifest.DebugManifest);
        //File.WriteAllBytes(androidManifestInProject, manifestFileInBytes);


        PlayerSettings.bundleVersion = DB.VC.dbVersion;
        PlayerSettings.Android.bundleVersionCode = DB.VC.dbVersionCode;

        

        SetSpecificAndroid(BuildTargetGroup.Android, "com.sloppystudio.a.de.pashekoshi", false);

    }

    [MenuItem("Switch/Debug/iOS")]
    public static void PrepareForiOSDebugging()
    {
        SetSpecificiOS(BuildTargetGroup.iOS, "com.sloppystudio.iOS.de.pashekoshi");
    }

    [MenuItem("Switch/Debug/WebGL")]
    public static void PrepareForWebGLDebugging()
    {
        GameData.CurrentBuildMode = BuildMode.debug;
        PlayerSettings.SetApplicationIdentifier(BuildTargetGroup.WebGL, "com.sloppystudio.WebGL.de.pashekoshi");
        SetSpecificWebGL();
    }


    [MenuItem("Switch/Store/Myket")]
    public static void PrepareForMyket()
    {
        GameData.CurrentBuildMode = BuildMode.release;

        PlayerSettings.bundleVersion = DB.VC.mkVersion;
        PlayerSettings.Android.bundleVersionCode = DB.VC.mkVersionCode;
        GameData.CurrentStoreForBuild = Store.Myket;
        //if (File.Exists(JarFile.CafeBazaarIn))
        //    File.Delete(JarFile.CafeBazaarIn);

        ////Copy Jar file from out into the plugins/android project instead of CafeBazaar
        //byte[] jarFileInBytes = File.ReadAllBytes(JarFile.MyketOut);
        //File.WriteAllBytes(JarFile.MyketIn, jarFileInBytes);

        ////Copy Manifest file from out into the plugins/android project instead of CafeBazaar
        //byte[] manifestFileInBytes = File.ReadAllBytes(Manifest.Myket);
        //File.WriteAllBytes(androidManifestInProject, manifestFileInBytes);

        SetSpecificAndroid(BuildTargetGroup.Android, bundleIdentifier);
    }

    [MenuItem("Switch/Store/Cafe Bazaar")]
    public static void PrepareForCafeBazaar()
    {
        GameData.CurrentBuildMode = BuildMode.release;

        PlayerSettings.bundleVersion = DB.VC.cbVersion;
        PlayerSettings.Android.bundleVersionCode = DB.VC.cbVersionCode;
        GameData.CurrentStoreForBuild = Store.CafeBazaar;

        ////Deleting Myket file before copying bazzar first 
        //if (File.Exists(JarFile.MyketIn))
        //    File.Delete(JarFile.MyketIn);

        ////Copy Jar file from out into the plugins/android project instead of Myket
        //byte[] jarFileInBytes = File.ReadAllBytes(JarFile.CafeBazaarOut);
        //File.WriteAllBytes(JarFile.CafeBazaarIn, jarFileInBytes);

        ////Copy Manifest file from out into the plugins/android project instead of Myket
        //byte[] manifestFileInBytes = File.ReadAllBytes(Manifest.CafeBazaar);
        //File.WriteAllBytes(androidManifestInProject, manifestFileInBytes);

        SetSpecificAndroid(BuildTargetGroup.Android, bundleIdentifier);
    }

    [MenuItem("Switch/Store/Zarinpal")]
    public static void PrepareForZarinpal()
    {
        PlayerSettings.bundleVersion = DB.VC.dbVersion;
        PlayerSettings.Android.bundleVersionCode = DB.VC.dbVersionCode;
        GameData.CurrentStoreForBuild = Store.Zarinpal;

        ////Deleting Bazaar file 
        //if (File.Exists(JarFile.CafeBazaarIn))
        //    File.Delete(JarFile.CafeBazaarIn);

        ////Deleting Myket file 
        //if (File.Exists(JarFile.MyketIn))
        //    File.Delete(JarFile.MyketIn);

        //Copy Manifest file from out into the plugins/android project instead of Myket or bazaar
        //byte[] manifestFileInBytes = File.ReadAllBytes(Manifest.Zarinpal);
        //File.WriteAllBytes(androidManifestInProject, manifestFileInBytes);

        SetSpecificAndroid(BuildTargetGroup.Android, bundleIdentifier);
    }


    [MenuItem("Switch/Store/Google Store")]
    public static void PrepareForGoogleStore()
    {
        GameData.CurrentBuildMode = BuildMode.release;

        PlayerSettings.bundleVersion = DB.VC.gsVersion;
        PlayerSettings.Android.bundleVersionCode = DB.VC.gsVersionCode;
        GameData.CurrentStoreForBuild = Store.GoogleStore;
        SetSpecificAndroid(BuildTargetGroup.Android, bundleIdentifier);
    }


    [MenuItem("Switch/Store/IranApps")]
    public static void PrepareForIranApps()
    {
        GameData.CurrentBuildMode = BuildMode.release;

        PlayerSettings.bundleVersion = DB.VC.iaVersion;
        PlayerSettings.Android.bundleVersionCode = DB.VC.iaVersionCode;
        GameData.CurrentStoreForBuild = Store.IranApps;
        SetSpecificAndroid(BuildTargetGroup.Android, bundleIdentifier);
    }

    [MenuItem("Switch/Store/Sib App")]
    public static void PrepareForSibApp()
    {
        GameData.CurrentBuildMode = BuildMode.release;

        PlayerSettings.bundleVersion = DB.VC.saVersion;
        GameData.CurrentStoreForBuild = Store.SibApp;
        SetSpecificiOS(BuildTargetGroup.iOS, bundleIdentifier);
    }

    [MenuItem("Switch/Store/App Store")]
    public static void PrepareForAppStore()
    {
        GameData.CurrentBuildMode = BuildMode.release;

        PlayerSettings.bundleVersion = DB.VC.asVersion;
        GameData.CurrentStoreForBuild = Store.AppleStore;
        SetSpecificiOS(BuildTargetGroup.iOS, bundleIdentifier);
    }

    #endregion

    #region Shared


    static void SwitchPlatform(BuildTargetGroup targetGroup, BuildTarget target)
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(targetGroup, target);
    }
    static void SetSpecificAndroid(BuildTargetGroup targetGroup, string bundleIdentifier, bool isCustomeKeyStore = true)
    {
        PlayerSettings.SetApplicationIdentifier(targetGroup, bundleIdentifier);
        SwitchPlatform(targetGroup, BuildTarget.Android);
        //todo update all of these in right time
        GameData.CurrentPlatform = Platform.Android;
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel22;
        PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLevelAuto;
        PlayerSettings.Android.useCustomKeystore = isCustomeKeyStore;//build as DEBUGE or for STORE
        if (isCustomeKeyStore)
        {
            PlayerSettings.Android.keystoreName = keystoreAddress;// keystore Address
            PlayerSettings.Android.keystorePass = keystorePass;// keystore password
            PlayerSettings.Android.keyaliasName = keyAliasAddress;// keyalias name
            PlayerSettings.Android.keyaliasPass = keyAliasPass;// keyalias password
        }
        else
        {
            PlayerSettings.Android.keystoreName = "keystoreAddress";// keystore Address
            PlayerSettings.Android.keystorePass = "keystorePass";// keystore password
            PlayerSettings.Android.keyaliasName = "keyAliasAddress";// keyalias name
            PlayerSettings.Android.keyaliasPass = "keyAliasPass";// keyalias password
        }
        SetScreenOrientation();

    }
    static void SetSpecificiOS(BuildTargetGroup targetGroup, string bundleIdentifier)
    {
        PlayerSettings.SetApplicationIdentifier(targetGroup, bundleIdentifier);
        SwitchPlatform(targetGroup, BuildTarget.iOS);
        GameData.CurrentPlatform = Platform.iOS;
        PlayerSettings.iOS.sdkVersion = iOSSdkVersion.DeviceSDK;
        SetScreenOrientation();
    }
    static void SetSpecificWebGL()
    {
        SwitchPlatform(BuildTargetGroup.WebGL, BuildTarget.WebGL);
        GameData.CurrentPlatform = Platform.WebGL;
        SetScreenOrientation();
    }

    static void SetScreenOrientation()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.autorotateToLandscapeRight = false;
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    static void SetAppIcon(BuildTargetGroup targetGroup)
    {
        Texture2D icon = Resourcer.TextureLoader("No Address yet!");
        Texture2D[] icons = new Texture2D[] { icon, icon, icon, icon };
        PlayerSettings.SetIconsForTargetGroup(targetGroup, icons);
    }


    #endregion



}//EndClasss

public struct Manifest
{
    public static string Myket { get { return @"..\Manifest\Myket\AndroidManifest.xml"; } }
    public static string CafeBazaar { get { return @"..\Manifest\CafeBazar\AndroidManifest.xml"; } }
    public static string Zarinpal { get { return @"..\Manifest\Zarinpal\AndroidManifest.xml"; } }
    public static string DebugManifest { get { return @"..\Manifest\Zarinpal\AndroidManifest.xml"; } }
}
public struct JarFile
{
    public static string MyketOut { get { return @"..\Manifest\Myket\MyketIAB.jar"; } }
    public static string CafeBazaarOut { get { return @"..\Manifest\CafeBazar\BazaarIAB.jar"; } }

    public static string MyketIn { get { return @"Assets\Plugins\Android\MyketIAB.jar"; } }
    public static string CafeBazaarIn { get { return @"Assets\Plugins\Android\BazaarIAB.jar"; } }
}