using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI CoinsText;
    [Space]
    [SerializeField] PowerupStruct PU_EPasheKosh;
    [Space]
    [SerializeField] PowerupStruct PU_Ghorse;
    [Space]
    [SerializeField] PowerupStruct PU_EFan;
    [Space]
    [SerializeField] PowerupStruct PU_Spray;

    int baseTaxOnEPashekosh = 0;
    int baseTaxOnGhors = 0;
    int baseTaxOnEFan = 0;
    int baseTaxOnSpray = 0;

    //Powerups.
    int puEPashekosh = 0;
    int puGhors = 0;
    int puEFan = 0;
    int puSpray = 0;

    //Powerups level.
    int puEPashekoshLevel = 0;
    int puGhorsLevel = 0;
    int puEFanLevel = 0;
    int puSprayLevel = 0;

    //Powerups Current Price.
    int puEPashekoshCurrentPrice = 0;
    int puGhorsCurrentPrice = 0;
    int puEFanCurrentPrice = 0;
    int puSprayCurrentPrice = 0;




    void Start()
    {
        UpdateAllPowerups();
    }






    #region Updating Powerups
    void UpdateAllPowerups()
    {
        UpdateEPashekoshStatus();
        UpdateGhorsStatus();
        UpdateEFanStatus();
        UpdateSprayStatus();
    }




    void UpdateEPashekoshStatus()
    {
        puEPashekoshLevel = PowerupRepo.GetPowerupLevel(PowerUpType.EPashekosh);
        puEPashekoshCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(PowerUpType.EPashekosh);

        PU_EPasheKosh.GetPU_LevelAndPrice(puEPashekoshLevel, puEPashekoshCurrentPrice);
        PU_EPasheKosh.LockPowerUp(CoinRepo.HasCoins(puEPashekoshCurrentPrice));
        PU_EPasheKosh.AddNewListener(delegate { PowerupLevelup(PowerUpType.EPashekosh, puEPashekoshCurrentPrice); });
    }
    void UpdateGhorsStatus()
    {
        puGhorsLevel = PowerupRepo.GetPowerupLevel(PowerUpType.Ghors);
        puGhorsCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(PowerUpType.Ghors);

        PU_Ghorse.GetPU_LevelAndPrice(puGhorsLevel, puGhorsCurrentPrice);
        PU_Ghorse.LockPowerUp(CoinRepo.HasCoins(puGhorsCurrentPrice));
        PU_Ghorse.AddNewListener(delegate { PowerupLevelup(PowerUpType.Ghors, puGhorsCurrentPrice); });
    }
    void UpdateEFanStatus()
    {
        puEFanLevel = PowerupRepo.GetPowerupLevel(PowerUpType.EFan);
        puEFanCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(PowerUpType.EFan);

        PU_EFan.GetPU_LevelAndPrice(puEFanLevel, puEFanCurrentPrice);
        PU_EFan.LockPowerUp(CoinRepo.HasCoins(puEFanCurrentPrice));
        PU_EFan.AddNewListener(delegate { PowerupLevelup(PowerUpType.EFan, puEFanCurrentPrice); });
    }
    void UpdateSprayStatus()
    {
        puSprayLevel = PowerupRepo.GetPowerupLevel(PowerUpType.Spray);
        puSprayCurrentPrice = PowerupRepo.GetPowerupCurrentPrice(PowerUpType.Spray);

        PU_Spray.GetPU_LevelAndPrice(puSprayLevel, puSprayCurrentPrice);
        PU_Spray.LockPowerUp(CoinRepo.HasCoins(puSprayCurrentPrice));
        PU_Spray.AddNewListener(delegate { PowerupLevelup(PowerUpType.Spray, puSprayCurrentPrice); });
    }



    void CalculateNewPrice(PowerUpType powerUp)
    {
        switch (powerUp)
        {
            case PowerUpType.EPashekosh:
                int EPasheKoshGap = 100;
                PowerupRepo.PushPowerupNewPrice(powerUp, EPasheKoshGap);
                break;

            case PowerUpType.Ghors:
                int GhorsGap = 150;
                PowerupRepo.PushPowerupNewPrice(powerUp, GhorsGap);
                break;

            case PowerUpType.EFan:
                int EFanGap = 200;
                PowerupRepo.PushPowerupNewPrice(powerUp, EFanGap);
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
            PowerupRepo.PushPowerupToNextLevel(powerUp);
            CalculateNewPrice(powerUp);
            CoinsText.text = CoinRepo.GetCoins().ToString();
            UpdateAllPowerups();
            Debug.Log("You bought " + powerUp + " with price of " + currentPrice + " coins!");
        }
        else
        {
            Debug.Log("You need at least " + currentPrice + " coins!");
        }
    }

#endregion






}
