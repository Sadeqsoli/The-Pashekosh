using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class PowerUpFunction : MonoBehaviour
{
    #region Fields

    public PowerUpType powerUpType;
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

    public void TriggerPowerUpFunction()
    {
        switch (powerUpType)
        {
            case PowerUpType.Fan:
                EventManager.TriggerEvent(Events.FanTriggered);
                break;
            case PowerUpType.Pill:
                EventManager.TriggerEvent(Events.PillTriggered);
                break;
            case PowerUpType.Spray:
                EventManager.TriggerEvent(Events.SprayTriggered);
                break;
        }
    }

    public void FinishedPowerUp()
    {
        GameManager.isPowerUpActive = false;
    }
    #endregion
}
