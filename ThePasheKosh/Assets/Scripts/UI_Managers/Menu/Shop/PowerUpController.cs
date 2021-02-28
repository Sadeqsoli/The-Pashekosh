using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{

    [SerializeField] RTLTextMeshPro CoinsText;
    [Space]
    [SerializeField] PowerupStruct PU_EPasheKosh;
    [Space]
    [SerializeField] PowerupStruct PU_Pill;
    [Space]
    [SerializeField] PowerupStruct PU_EFan;
    [Space]
    [SerializeField] PowerupStruct PU_Spray;


    //base taxes.
    int baseTaxOnEPashekosh = 0;
    int baseTaxOnPill = 0;
    int baseTaxOnEFan = 0;
    int baseTaxOnSpray = 0;

    //Powerups.
    int puEPashekosh = 0;
    int puPill = 0;
    int puEFan = 0;
    int puSpray = 0;






    void OnEnable()
    {
        InitializePowerups();
    }

    void InitializePowerups()
    {
        CoinsText.text = CoinRepo.GetCoins().ToString();
        UpdateAllPowerups();
    }




    #region Updating Powerups
    void UpdateAllPowerups()
    {
        UpdateEPashekoshStatus();
        UpdatePillStatus();
        UpdateEFanStatus();
        UpdateSprayStatus();
    }




    void UpdateEPashekoshStatus()
    {

        int puEPashekoshLevel = PowerupRepo.GetPowerupLevel(PowerUpType.ElectricalPasheKosh);
        int puEPashekoshCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(PowerUpType.ElectricalPasheKosh);

        Debug.Log("puEPashekoshLevel: " + puEPashekoshLevel);
        Debug.Log("puEPashekoshCurrentPrice: " + puEPashekoshCurrentPrice);

        PU_EPasheKosh.GetPU_LevelAndPrice(puEPashekoshLevel, puEPashekoshCurrentPrice);
        PU_EPasheKosh.LockPowerUp(CoinRepo.HasCoins(puEPashekoshCurrentPrice));
        PU_EPasheKosh.AddNewListener(delegate { PowerupLevelup(PowerUpType.ElectricalPasheKosh, puEPashekoshCurrentPrice); });
    }
    void UpdatePillStatus()
    {
        int puPillLevel = PowerupRepo.GetPowerupLevel(PowerUpType.Pill);
        int puPillCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(PowerUpType.Pill);

        Debug.Log("puPillLevel: " + puPillLevel);
        Debug.Log("puPillCurrentPrice: " + puPillCurrentPrice);

        PU_Pill.GetPU_LevelAndPrice(puPillLevel, puPillCurrentPrice);
        PU_Pill.LockPowerUp(CoinRepo.HasCoins(puPillCurrentPrice));
        PU_Pill.AddNewListener(delegate { PowerupLevelup(PowerUpType.Pill, puPillCurrentPrice); });
    }
    void UpdateEFanStatus()
    {

        int puEFanLevel = PowerupRepo.GetPowerupLevel(PowerUpType.Fan);
       int puEFanCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(PowerUpType.Fan);

        Debug.Log("puEFanLevel: " + puEFanLevel);
        Debug.Log("puEFanCurrentPrice: " + puEFanCurrentPrice);

        PU_EFan.GetPU_LevelAndPrice(puEFanLevel, puEFanCurrentPrice);
        PU_EFan.LockPowerUp(CoinRepo.HasCoins(puEFanCurrentPrice));
        PU_EFan.AddNewListener(delegate { PowerupLevelup(PowerUpType.Fan, puEFanCurrentPrice); });
    }
    void UpdateSprayStatus()
    {
        PowerUpType spray = PowerUpType.Spray;
        int puSprayLevel = PowerupRepo.GetPowerupLevel(spray);
        int puSprayCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(spray);

        Debug.Log("puSprayLevel: " + puSprayLevel);
        Debug.Log("puSprayCurrentPrice: " + puSprayCurrentPrice);

        PU_Spray.GetPU_LevelAndPrice(puSprayLevel, puSprayCurrentPrice);
        PU_Spray.LockPowerUp(CoinRepo.HasCoins(puSprayCurrentPrice));
        PU_Spray.AddNewListener(delegate { PowerupLevelup(spray, puSprayCurrentPrice); });
    }



    void CalculateNewPrice(PowerUpType powerUp)
    {
        switch (powerUp)
        {
            case PowerUpType.ElectricalPasheKosh:
                int EPasheKoshGap = 100;
                PowerupRepo.PushPowerupNewPrice(powerUp, EPasheKoshGap);
                break;

            case PowerUpType.Fan:
                int EFanGap = 150;
                PowerupRepo.PushPowerupNewPrice(powerUp, EFanGap);
                break;

            case PowerUpType.Pill:
                int PillGap = 200;
                PowerupRepo.PushPowerupNewPrice(powerUp, PillGap);
                break;

            case PowerUpType.Spray:
                int SprayGap = 250;
                PowerupRepo.PushPowerupNewPrice(powerUp, SprayGap);
                break;

        }
    }
    #endregion


    #region Powerups Levelup




    void PowerupLevelup(PowerUpType powerUp, int currentPrice)
    {
        if (CoinRepo.PopCoins(currentPrice))
        {
            CoinsText.text = CoinRepo.GetCoins().ToString();
            PowerupRepo.PushPowerupToNextLevel(powerUp);
            CalculateNewPrice(powerUp);
            UpdateAllPowerups();
            Debug.Log("You've bought " + powerUp + " with price of " + currentPrice + " coins!");
        }
        else
        {
            Debug.Log("You need at least " + currentPrice + " coins!");
        }
    }

#endregion

}//EndClassss
