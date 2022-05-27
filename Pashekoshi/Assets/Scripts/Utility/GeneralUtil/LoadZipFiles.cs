using UnityEngine;
using System.Collections;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;
using System.ComponentModel;

public static class LoadZipFiles
{
#if UNITY_IPHONE
    [DllImport("__Internal")]
    private static extern void unzip (string zipFilePath, string location);
 
    [DllImport("__Internal")]
    private static extern void zip (string zipFilePath);
 
    [DllImport("__Internal")]
    private static extern void addZipFile (string addFile);
 
#endif


    public static void Unzip(string zipFilePath, string location)
    {

#if UNITY_ANDROID
        using (AndroidJavaClass zipper = new AndroidJavaClass ("com.tsw.zipper")) {
            zipper.CallStatic ("unzip", zipFilePath, location);
        }
#elif UNITY_IPHONE
        unzip (zipFilePath, location);
#endif
    }

    public static void Zip(string zipFileName, params string[] files)
    {

#if UNITY_ANDROID
        using (AndroidJavaClass zipper = new AndroidJavaClass ("com.tsw.zipper")) {
            {
                zipper.CallStatic ("zip", zipFileName, files);
            }
        }
#elif UNITY_IPHONE
        foreach (string file in files) {
            addZipFile (file);
        }
        zip (zipFileName);
#endif
    }
}//EndClassss/SadeQ
