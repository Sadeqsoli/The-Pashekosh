using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowerupRepo
{
    #region Properties
    public static string PowerupRepos { get { return PURepository; } }
    #endregion

    #region Fields
    const string PURepository = "powerupRepository";

    const string PU_EPashekoshLevel = "powerupEPashekoshLevelRepository";
    const string PU_GhorsLevel = "powerupGhorsLevelRepository";
    const string PU_EFanLevel = "powerupEFanLevelRepository";
    const string PU_SprayLevel = "powerupSprayLevelRepository";

    const string PU_EPashekoshPrice = "powerupEPashekoshPriceRepository";
    const string PU_GhorsPrice = "powerupGhorsPriceRepository";
    const string PU_EFanPrice = "powerupEFanPriceRepository";
    const string PU_SprayPrice = "powerupSprayPriceRepository";
    #endregion

    #region Public Methods

    public static void PushPowerupToNextLevel(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.EPashekosh:
                int EPashekoshPowerups = GetPowerupLevel(powerUpType);
                EPashekoshPowerups += 1;
                SaveRepo(PU_EPashekoshLevel, EPashekoshPowerups);
                break;
            case PowerUpType.Ghors:
                int GhorsPowerups = GetPowerupLevel(powerUpType);
                GhorsPowerups += 1;
                SaveRepo(PU_GhorsLevel, GhorsPowerups);
                break;
            case PowerUpType.EFan:
                int EFanPowerups = GetPowerupLevel(powerUpType);
                EFanPowerups += 1;
                SaveRepo(PU_EFanLevel, EFanPowerups);
                break;
            case PowerUpType.Spray:
                int SprayPowerups = GetPowerupLevel(powerUpType);
                SprayPowerups += 1;
                SaveRepo(PU_SprayLevel, SprayPowerups);
                break;
        }

    }
    public static int GetPowerupLevel(PowerUpType powerUp)
    {
        int PU_Number = 0;
        switch (powerUp)
        {
            case PowerUpType.EPashekosh:
                if (PlayerPrefs.HasKey(PU_EPashekoshLevel))
                    PU_Number = Retrive(PU_EPashekoshLevel);
                break;
            case PowerUpType.Ghors:
                if (PlayerPrefs.HasKey(PU_GhorsLevel))
                    PU_Number = Retrive(PU_GhorsLevel);
                break;
            case PowerUpType.EFan:
                if (PlayerPrefs.HasKey(PU_EFanLevel))
                    PU_Number = Retrive(PU_EFanLevel);
                break;
            case PowerUpType.Spray:
                if (PlayerPrefs.HasKey(PU_SprayLevel))
                    PU_Number = Retrive(PU_SprayLevel);
                break;
        }
        return PU_Number;
    }

    public static void PushPowerupNewPrice(PowerUpType powerUpType, int newGap)
    {
        switch (powerUpType)
        {
            case PowerUpType.EPashekosh:
                int EPashekoshPowerupsPrice = GetPowerupCurrentPrice(powerUpType);
                EPashekoshPowerupsPrice += newGap;
                SaveRepo(PU_EPashekoshPrice, EPashekoshPowerupsPrice);
                break;

            case PowerUpType.Ghors:
                int GhorsPowerupsPrice = GetPowerupCurrentPrice(powerUpType);
                GhorsPowerupsPrice += newGap;
                SaveRepo(PU_GhorsPrice, GhorsPowerupsPrice);
                break;

            case PowerUpType.EFan:
                int EFanPowerupsPrice = GetPowerupCurrentPrice(powerUpType);
                EFanPowerupsPrice += newGap;
                SaveRepo(PU_EFanPrice, EFanPowerupsPrice);
                break;

            case PowerUpType.Spray:
                int SprayPowerupsPrice = GetPowerupCurrentPrice(powerUpType);
                SprayPowerupsPrice += newGap;
                SaveRepo(PU_SprayPrice, SprayPowerupsPrice);
                break;
        }

    }
    public static int GetPowerupCurrentPrice(PowerUpType powerUp)
    {
        int PU_CurrentPrice = 0;
        switch (powerUp)
        {
            case PowerUpType.EPashekosh:
                PU_CurrentPrice = Retrive(PU_EPashekoshPrice);
                break;
            case PowerUpType.Ghors:
                PU_CurrentPrice = Retrive(PU_GhorsPrice);
                break;
            case PowerUpType.EFan:
                PU_CurrentPrice = Retrive(PU_EFanPrice);
                break;
            case PowerUpType.Spray:
                PU_CurrentPrice = Retrive(PU_SprayPrice);
                break;
        }
        return PU_CurrentPrice;
    }




    #endregion

    #region Private Methods



    static int Retrive(string repoKey)
    {
        return PlayerPrefs.GetInt(repoKey);
    }

    static void SaveRepo(string repoKey, int value)
    {
        PlayerPrefs.SetInt(repoKey, value);
    }


    #endregion
}
public enum PowerUpType { EPashekosh, Ghors, EFan, Spray }