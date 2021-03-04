using UnityEngine;


public static class LockRepo
{

    public static void OpenLock(string key, bool value)
    {
        SetBool(key, value);
    }

    public static bool IsOpened(string key)
    {
        return GetBool(key);
    }



    static bool GetBool(string key)
    {
        return (PlayerPrefs.GetInt(key) == 1);
    }
    static void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

}//EndClasssss


