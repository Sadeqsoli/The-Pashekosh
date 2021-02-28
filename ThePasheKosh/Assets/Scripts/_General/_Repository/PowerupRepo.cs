using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PowerupRepo
{

    #region Fields

    const string PU_EPashekoshLevel = "powerupEPashekoshLevelRepository";
    const string PU_PillLevel = "powerupPillLevelRepository";
    const string PU_EFanLevel = "powerupEFanLevelRepository";
    const string PU_SprayLevel = "powerupSprayLevelRepository";

    const string PU_EPashekoshPrice = "powerupEPashekoshPriceRepository";
    const string PU_PillPrice = "powerupPillPriceRepository";
    const string PU_EFanPrice = "powerupEFanPriceRepository";
    const string PU_SprayPrice = "powerupSprayPriceRepository";



    //Powerups level.
    static int puEPashekoshLevel = 1;
    static int puGhorsLevel = 1;
    static int puEFanLevel = 1;
    static int puSprayLevel = 1;

    //Powerups Current Price.
    static int puEPashekoshCurrentPrice = 0;
    static int puGhorsCurrentPrice = 0;
    static int puEFanCurrentPrice = 0;
    static int puSprayCurrentPrice = 0;
    #endregion

    #region Public Methods

    public static void PushPowerupToNextLevel(PowerUpType powerUpType)
    {
        switch (powerUpType)
        {
            case PowerUpType.ElectricalPasheKosh:
                int EPashekoshPowerups = GetPowerupLevel(powerUpType);
                EPashekoshPowerups += 1;
                SaveRepo(PU_EPashekoshLevel, EPashekoshPowerups);
                break;
            case PowerUpType.Fan:
                int EFanPowerups = GetPowerupLevel(powerUpType);
                EFanPowerups += 1;
                SaveRepo(PU_EFanLevel, EFanPowerups);
                break;
            case PowerUpType.Pill:
                int GhorsPowerups = GetPowerupLevel(powerUpType);
                GhorsPowerups += 1;
                SaveRepo(PU_PillLevel, GhorsPowerups);
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
        int PU_Number = 1;
        switch (powerUp)
        {
            case PowerUpType.ElectricalPasheKosh:
                if (PlayerPrefs.HasKey(PU_EPashekoshLevel))
                {
                    PU_Number = Retrive(PU_EPashekoshLevel);
                }
                else
                {
                    SaveRepo(PU_EPashekoshLevel, 1);
                }
                break;

            case PowerUpType.Fan:
                if (PlayerPrefs.HasKey(PU_EFanLevel))
                {
                    PU_Number = Retrive(PU_EFanLevel);
                }
                else
                {
                    SaveRepo(PU_EFanLevel, 1);
                }
                break;

            case PowerUpType.Pill:
                if (PlayerPrefs.HasKey(PU_PillLevel))
                {
                    PU_Number = Retrive(PU_PillLevel);
                }
                else
                {
                    SaveRepo(PU_PillLevel, 1);
                }
                break;

            case PowerUpType.Spray:
                if (PlayerPrefs.HasKey(PU_SprayLevel))
                {
                    PU_Number = Retrive(PU_SprayLevel);
                }
                else
                {
                    SaveRepo(PU_SprayLevel, 1);
                }
                break;
        }
        return PU_Number;
    }

    public static void PushPowerupNewPrice(PowerUpType powerUpType, int newGap)
    {
        switch (powerUpType)
        {
            case PowerUpType.ElectricalPasheKosh:
                int EPashekoshPowerupsPrice = GetPowerupCurrentPrice(powerUpType);
                EPashekoshPowerupsPrice += newGap;
                SaveRepo(PU_EPashekoshPrice, EPashekoshPowerupsPrice);
                break;

            case PowerUpType.Fan:
                int EFanPowerupsPrice = GetPowerupCurrentPrice(powerUpType);
                EFanPowerupsPrice += newGap;
                SaveRepo(PU_EFanPrice, EFanPowerupsPrice);
                break;

            case PowerUpType.Pill:
                int GhorsPowerupsPrice = GetPowerupCurrentPrice(powerUpType);
                GhorsPowerupsPrice += newGap;
                SaveRepo(PU_PillPrice, GhorsPowerupsPrice);
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
        int PU_CurrentPrice = 100;
        switch (powerUp)
        {
            case PowerUpType.ElectricalPasheKosh:
                if (PlayerPrefs.HasKey(PU_EPashekoshPrice))
                {
                    PU_CurrentPrice = Retrive(PU_EPashekoshPrice);
                }
                else
                {
                    PU_CurrentPrice = 100;
                }

                break;
            case PowerUpType.Fan:
                if (PlayerPrefs.HasKey(PU_EFanPrice))
                {
                    PU_CurrentPrice = Retrive(PU_EFanPrice);
                }
                else
                {
                    PU_CurrentPrice = 150;
                }
                break;
            case PowerUpType.Pill:
                if (PlayerPrefs.HasKey(PU_PillPrice))
                {
                    PU_CurrentPrice = Retrive(PU_PillPrice);
                }
                else
                {
                    PU_CurrentPrice = 200;
                }
                break;
            case PowerUpType.Spray:
                if (PlayerPrefs.HasKey(PU_SprayPrice))
                {
                    PU_CurrentPrice = Retrive(PU_SprayPrice);
                }
                else
                {
                    PU_CurrentPrice = 250;
                }
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

