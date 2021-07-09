using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DB
{
    internal class SFXs
    {
        public string ButtonClick { get { return ""; } }
    }

    const string BaseURLPath = "http://www.sloppystudio.ir";


    const string localBcakgrondPath = @"IMG/Backgrounds/";
    const string localMusicPath = @"Audio/Musics/";
    const string localSFXPath = @"Audio/SFXs/";
    const string MP3Format = ".mp3";
    const string JPGFormat = ".jpg";
    const string PNGFormat = ".png";



    public static string Key(FoodType targetType)
    {
        return "KeyRepoFor" + targetType;
    }
    public static string Key(WeaponType weaponType)
    {
        return "KeyRepoFor" + weaponType;
    }



    public static string LocalBackPath(string backgroundName)
    {
        return  localBcakgrondPath + backgroundName + PNGFormat;
    }



    public static string LocalMusicsDIR()
    {
        return  localMusicPath;
    }





    public static string LocalSFXs(int sfxNumb)
    {
        return  localSFXPath + sfxNumb + MP3Format;
    }
    public static string LocalSFXsDIR()
    {
        return  localSFXPath;
    }




}//EndClassss
