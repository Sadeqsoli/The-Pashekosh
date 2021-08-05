using System;
using UnityEngine;

public static class Enumer
{
    public static string[] GetNames<T>()
    {
        return Enum.GetNames(typeof(T));
    }

    public static T ParseEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    public static bool IsEnumEqual<T>(T type, string[] targetType)
    {
        int targetLength = targetType.Length;
        for (int i = 0; i < targetLength; i++)
        {
            T currentAvailablePlot = ParseEnum<T>(targetType[i]);
            if (type.Equals(currentAvailablePlot))
                return true;
        }
        return false;
    }
}

