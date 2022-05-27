using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetRepo 
{
    #region Properties

    #endregion

    #region Fields
    const string TargetFoodRepository = "TargetFoodRepository";

    #endregion

    #region Public Methods

    public static void Push(FoodType newFood)
    {
        Save(TargetFoodRepository, (int)newFood);
    }

    public static FoodType Get()
    {

        return (FoodType)Retrive(TargetFoodRepository);
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
