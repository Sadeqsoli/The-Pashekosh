using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DB 
{
    
    public static string Key(FoodType targetType)
    {
        return "KeyRepoFor" + targetType;
    }
    public static string Key(WeaponType weaponType)
    {
        return "KeyRepoFor" + weaponType;
    }

}
