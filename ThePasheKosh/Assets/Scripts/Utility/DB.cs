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


    const string localBcakgrondPath = "/Pashe/IMG/Backgrounds/";
    const string localMusicPath = "/Pashe/Audio/Musics/";
    const string localSFXPath = "/Pashe/Audio/SFXs/";
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



    public static string LocalBackgroundDIR()
    {
        return Application.persistentDataPath + localBcakgrondPath;
    }
    public static string ServerBackgroundDIR()
    {
        return BaseURLPath + localBcakgrondPath;
    }
    public static string LocalBackPath(string backgroundName)
    {
        return Application.persistentDataPath + localBcakgrondPath + backgroundName + PNGFormat;
    }
    public static string ServerBackPath(string backgroundName)
    {
        return BaseURLPath + localBcakgrondPath + backgroundName + PNGFormat;
    }


    public static string LocalMusicsDIR()
    {
        return Application.persistentDataPath + localMusicPath;
    }
    public static string ServerMusicsDIR()
    {
        return BaseURLPath + localMusicPath;
    }
    public static string LocalMusics(string musicName)
    {
        return Application.persistentDataPath + localMusicPath + musicName + MP3Format;
    }
    public static string ServerMusics(string musicName)
    {
        return BaseURLPath + localMusicPath + musicName + MP3Format;
    }




    public static string LocalSFXsDIR()
    {
        return Application.persistentDataPath + localSFXPath;
    }
    public static string ServerSFXsDIR()
    {
        return BaseURLPath + localSFXPath;
    }
    public static string LocalSFXs(string sfxName)
    {
        return Application.persistentDataPath + localSFXPath + sfxName + MP3Format;
    }
    public static string ServerSFXs(string sfxName)
    {
        return BaseURLPath + localSFXPath+ sfxName + MP3Format;
    }



}//EndClassss
