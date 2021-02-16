using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    #region Fields

    public static int ElectricalPasheKoshNum { get; private set; }
    public static int FanNum { get; private set; }
    public static int PillNum { get; private set; }
    public static int SprayNum { get; private set; }
    #endregion

    #region Propertie
    #endregion

    #region Unity Methods

    #endregion

    #region Methods
    
    public static void Initialize(PowerUpNumbers powerUpsNumbers)
    {
        ElectricalPasheKoshNum = powerUpsNumbers.electricalPasheKoshNum;
        FanNum = powerUpsNumbers.fanNum;
        PillNum = powerUpsNumbers.pillNum;
        SprayNum = powerUpsNumbers.sprayNum;
        
        PowerUps.UpdatePowerUp(ElectricalPasheKoshNum, FanNum, PillNum, SprayNum);
    }

    public void UseElectricalPasheKosh()
    {
        if (ElectricalPasheKoshNum > 0)
        {
            ElectricalPasheKoshNum--;
            // ** Use electrical pashe kosh and Show it
            PowerUps.DecreaseElectricalNum();
            EventManager.TriggerEvent(Events.ElectricalPasheKosh);
        }
    }

    public void UseFan()
    {
        if (FanNum > 0)
        {
            FanNum--;
            // ** Use Fan and Show it
            PowerUps.DecreaseFanNum();
            EventManager.TriggerEvent(Events.Fan);
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
        }
    }
    #endregion
}
