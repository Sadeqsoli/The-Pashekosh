using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoinRepo
{
    #region Properties
    public static string CoinRepos { get { return coinRepository; } }
    #endregion

    #region Fields
    const string coinRepository = "coinRepository";
    #endregion

    #region Public Methods
    public static bool PopCoins(int count)
    {
        if (HasCoins(count))
        {
            int allCoins = GetCoins();
            allCoins -= count;
            SaveRepo(coinRepository, allCoins);
            return true;
        }
        return false;

    }
    public static void PushCoins(int newCoins)
    {
        if (newCoins > 0)
        {
            int coins = GetCoins();
            coins += newCoins;
            SaveRepo(coinRepository, coins);
        }
    }
    public static int GetCoins()
    {
        return Retrive(coinRepository);
    }




    #endregion

    #region Private Methods




    static bool HasCoins(int Count)
    {
        int coins = GetCoins();
        if (coins >= Count)
        {
            return true;
        }
        return false;
    }



    static int Retrive(string repoKey)
    {
        return PlayerPrefs.GetInt(repoKey);
    }

    static void SaveRepo(string repoKey, int coins)
    {
        PlayerPrefs.SetInt(repoKey, coins);
    }

    #endregion
}//EndClasssss/SadeQ
