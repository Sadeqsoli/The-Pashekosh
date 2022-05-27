using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerUpsManager : MonoBehaviour
{
    #region Fields

    public static int ElectricalPasheKoshNum { get; private set; }
    public static int FanNum { get; private set; }
    public static int PillNum { get; private set; }
    public static int SprayNum { get; private set; }


    public Transform screenCenter;

    // Power Ups Effects Prefabs
    [Header("Prefabs")]
    public GameObject gasFcPrefab;
    public GameObject sprayFcPrefab;
    public GameObject windFcPrefab;
    
    #endregion

    #region Propertie
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        var powerUpsNumbers = GetPowerUpsNum();
        
        ElectricalPasheKoshNum = powerUpsNumbers.electricalPasheKoshNum;
        FanNum = powerUpsNumbers.fanNum;
        PillNum = powerUpsNumbers.pillNum;
        SprayNum = powerUpsNumbers.sprayNum;
        
        PowerUps.UpdatePowerUp(ElectricalPasheKoshNum, FanNum, PillNum, SprayNum);
    }

    private void OnDisable()
    {
        var powerUpsNumbers = GetPowerUpsNum();
        
        powerUpsNumbers.electricalPasheKoshNum = ElectricalPasheKoshNum;
        powerUpsNumbers.fanNum = FanNum;
        powerUpsNumbers.pillNum = PillNum;
        powerUpsNumbers.sprayNum = SprayNum;
        
        SavePowerUpsNum(powerUpsNumbers);
    }

    #endregion

    #region Methods
    
    

    public void UseElectricalPasheKosh()
    {
        if (ElectricalPasheKoshNum > 0)
        {
            ElectricalPasheKoshNum--;
            // Use electrical pashe kosh
            PowerUps.DecreaseElectricalNum();
            EventManager.TriggerEvent(Events.ElectricalPasheKosh);
            
            // ** Use Electrical Pashe Kosh
            EventManager.TriggerEvent(Events.ElectricalPasheKoshTriggered);
        }
    }

    public void UseFan()
    {
        if (FanNum > 0)
        {
            FanNum--;
            // Use Fan and Show it
            PowerUps.DecreaseFanNum();
            EventManager.TriggerEvent(Events.Fan);
            
            // Show the effect of fan
            Instantiate(windFcPrefab, screenCenter.position, Quaternion.identity);
        }
    }

    public void UsePill()
    {
        if (PillNum > 0)
        {
            PillNum--;
            // ** Use Pill and Show it
            PowerUps.DecreasePillNum();
            EventManager.TriggerEvent(Events.Pill);
            
            // Show the effect of pill
            Instantiate(gasFcPrefab, screenCenter.position, Quaternion.identity);
        }
    }

    public void UseSpray()
    {
        if (SprayNum > 0)
        {
            SprayNum--;
            // ** Use Spray and Show it
            PowerUps.DecreaseSprayNum();
            EventManager.TriggerEvent(Events.Spray);
            
            // Show the effect of pill
            Instantiate(sprayFcPrefab, screenCenter.position, Quaternion.identity);
        }
    }
    
    public static PowerUpNumbers GetPowerUpsNum()
    {
        PowerUpNumbers powerUpNumbers = new PowerUpNumbers();
        if (PlayerPrefs.HasKey(PowerUps.ElectricalPasheKosh))
        {
            powerUpNumbers.electricalPasheKoshNum = PlayerPrefs.GetInt(PowerUps.ElectricalPasheKosh);
            powerUpNumbers.fanNum = PlayerPrefs.GetInt(PowerUps.Fan);
            powerUpNumbers.pillNum = PlayerPrefs.GetInt(PowerUps.Pill);
            powerUpNumbers.sprayNum = PlayerPrefs.GetInt(PowerUps.Spray);
        }
        else
        {
            Debug.Log("Number Of PowerUps haven't saved from Main Menu Scene.");
            powerUpNumbers.electricalPasheKoshNum = 1;
            powerUpNumbers.fanNum = 1;
            powerUpNumbers.pillNum = 1;
            powerUpNumbers.sprayNum = 1;
        }

        return powerUpNumbers;
    }

    public static void SavePowerUpsNum(PowerUpNumbers powerUpNumbers)
    {
        PlayerPrefs.SetInt(PowerUps.ElectricalPasheKosh, 1);//powerUpNumbers.electricalPasheKoshNum);
        PlayerPrefs.SetInt(PowerUps.Fan, 1);//powerUpNumbers.fanNum);
        PlayerPrefs.SetInt(PowerUps.Pill, 1);// powerUpNumbers.pillNum);
        PlayerPrefs.SetInt(PowerUps.Spray, 1); //powerUpNumbers.sprayNum);
    }
    
    #endregion
}
