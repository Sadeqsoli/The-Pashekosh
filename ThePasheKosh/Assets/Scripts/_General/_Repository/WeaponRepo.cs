using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRepo : MonoBehaviour
{
    #region Properties

    #endregion

    #region Fields
    const string WeaponRepository = "WeaponRepository";

    #endregion

    #region Public Methods

    public static void Push(WeaponType newWeapon)
    {
        Save(WeaponRepository, (int)newWeapon);
    }

    public static WeaponType Get()
    {

        return (WeaponType)Retrive(WeaponRepository);
    }

    #endregion




    #region Private Methods


    static int Retrive(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    static void Save(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
    }




    #endregion
}
