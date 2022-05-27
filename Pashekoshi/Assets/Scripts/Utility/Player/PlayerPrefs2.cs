using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefs2
{
    private static void AddToPool<T>(IDictionary<string, Action<T>> pool, string key, Action<T> item)
    {
        if (item == null) return;
        RemoveFromPool(pool, key);
        pool.Add(key, item);
    }

    private static void RemoveFromPool<T>(IDictionary<string, Action<T>> pool, string key)
    {
        if (pool.ContainsKey(key)) pool.Remove(key);
    }

    private static void CallIfAvailable<T>(IDictionary<string, Action<T>> pool, string key, T input)
    {
        if (pool != null && pool.ContainsKey(key)) pool[key](input);
    }

    //For Tutorials in game for beginners.
    public static void SetBool(string key, bool state)
    {
        PlayerPrefs.SetInt(key, state ? 1 : 0);
    }

    public static bool GetBool(string key)
    {
        return (PlayerPrefs.GetInt(key) == 1);
    }

}//EndClasssss/SadeQ
