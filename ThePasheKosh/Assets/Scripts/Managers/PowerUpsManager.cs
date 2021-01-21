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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #endregion

    #region Methods

    public static void Initialize(PowerUpNumbers powerUpsNumbers)
    {
        ElectricalPasheKoshNum = powerUpsNumbers.electricalPasheKoshNum;
        FanNum = powerUpsNumbers.fanNum;
        PillNum = powerUpsNumbers.pillNum;
        SprayNum = powerUpsNumbers.sprayNum;
    }
    #endregion
}
