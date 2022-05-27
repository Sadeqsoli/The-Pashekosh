using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class DB
{
    public class VC
    {
        public static int dbVersionCode = 1;
        public static string dbVersion { get { return "1.1.2"; } }

        public static int mkVersionCode = 1;
        public static string mkVersion { get { return "1.1.2"; } }

        public static int cbVersionCode = 1;
        public static string cbVersion { get { return "1.1.2"; } }

        public static int gsVersionCode = 1;
        public static string gsVersion { get { return "1.1.2"; } }

        public static int iaVersionCode = 1;
        public static string iaVersion { get { return "1.1.2"; } }

        public static string saVersion { get { return "1.1.2"; } }
        public static string asVersion { get { return "1.1.2"; } }
    }


    const string BaseURLPath = "http://www.sloppystudio.ir";


    const string localBcakgrondPath = @"IMG/Backgrounds/";
    const string localMusicPath = @"Audio/Musics";
    const string localSFXPath = @"Audio/SFXs/";
    const string MP3Format = ".mp3";
    const string JPGFormat = ".jpg";
    const string PNGFormat = ".png";
    internal class BugSFXs
    {
        public string fly { get; } = localSFXPath + "Insects/" + MP3Format;
    }


    public static string Key(FoodType targetType)
    {
        StringBuilder keyForTargetFood = new StringBuilder();
        keyForTargetFood.Append("KeyRepoFor").Append(targetType);
        return keyForTargetFood.ToString();
    }
    public static string Key(WeaponType weaponType)
    {
        StringBuilder keyForTargetWeapon = new StringBuilder();
        keyForTargetWeapon.Append("KeyRepoFor").Append(weaponType);
        return keyForTargetWeapon.ToString();
    }



    public static string LocalBackPath(string backgroundName)
    {
        StringBuilder localBackground = new StringBuilder();
        localBackground.Append(localBcakgrondPath).Append(backgroundName).Append(PNGFormat);
        return localBackground.ToString();
    }



    public static string LocalMusicsDIR()
    {
        StringBuilder localBackgroundDIR = new StringBuilder(localMusicPath);
        return localBackgroundDIR.ToString();
    }





    public static string LocalSFXs(int sfxNumb)
    {
        StringBuilder localSFX = new StringBuilder();
        localSFX.Append(localSFXPath).Append(sfxNumb).Append(MP3Format);
        return localSFX.ToString();
    }
    public static string LocalSFXsDIR()
    {
        StringBuilder localSFXDIR = new StringBuilder(localSFXPath);
        return localSFXDIR.ToString();
    }




}//EndClassss
