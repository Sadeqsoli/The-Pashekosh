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
    [SerializeField] PowerupStruct PU_EFan;
    [Space]
    [SerializeField] PowerupStruct PU_Pill;
    [Space]
    [SerializeField] PowerupStruct PU_Spray;


    //base taxes.
    int baseTaxOnEPashekosh = 0;
    int baseTaxOnPill = 0;
    int baseTaxOnEFan = 0;
    int baseTaxOnSpray = 0;

    //Powerups Numbers.
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
        UpdatePowerUpStatus(PU_EPasheKosh,PowerUpType.ElectricalPasheKosh);
        UpdatePowerUpStatus(PU_EFan, PowerUpType.Fan);
        UpdatePowerUpStatus(PU_Pill, PowerUpType.Pill);
        UpdatePowerUpStatus(PU_Spray, PowerUpType.Spray);
    }





    #endregion


    #region Powerups Levelup
    void UpdatePowerUpStatus(PowerupStruct powerupStruct, PowerUpType power)
    {
        int currentPrice_PU = PowerupRepo.GetPowerupCurrentPrice(power);
        powerupStruct.GetPU_LevelAndPrice(power);
        powerupStruct.LockPowerUp(CoinRepo.HasCoins(currentPrice_PU));
        powerupStruct.AddNewListener(delegate { PowerupLevelup(power, currentPrice_PU); });
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



    void PowerupLevelup(PowerUpType powerUp, int currentPrice)
    {
        if (CoinRepo.PopCoins(currentPrice))
        {
            SFXPlayer.Instance.PlaySFX(UIFeedback.BuyOrSelectItem);
            PowerupRepo.PushPowerupToNextLevel(powerUp);
            CalculateNewPrice(powerUp);
            InitializePowerups();
            Debug.Log("You've bought " + powerUp + " with price of " + currentPrice + " coins!");
        }
        else
        {
            SFXPlayer.Instance.PlaySFX(UIFeedback.Locked);
            Debug.Log("You need at least " + currentPrice + " coins!");
        }
    }

#endregion

}//EndClassss
