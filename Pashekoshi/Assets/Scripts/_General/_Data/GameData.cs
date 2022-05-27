

public static class GameData
{
    public static Store CurrentStoreForBuild;
    public static Platform CurrentPlatform;
    public static BuildMode CurrentBuildMode;
}

public enum Store { Zarinpal, CafeBazaar, Myket, IranApps, GoogleStore, SibApp, AppleStore }
public enum Platform { Android, iOS , WebGL }
public enum BuildMode {debug,openBeta, release}


public static class GameURLs
{
    public static url BaseGameUrl = new url("","","");
    public static url BaseBundleUrl;
}

public  class url
{
    public url(string Release, string OpenBeta, string Debug)
    {
        release = Release;
        openBeta = OpenBeta;
        debug = Debug;
    }

    public  string release;
    public string openBeta;
    public string debug;
}