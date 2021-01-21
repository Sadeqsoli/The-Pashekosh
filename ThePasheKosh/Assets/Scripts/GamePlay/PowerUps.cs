using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;

public class PowerUps : MonoBehaviour
{
    #region Fields

    public GameObject electricalPasheKosh;
    public GameObject fan;
    public GameObject pill;
    public GameObject spray;

    private Button electricalPasheKoshButton;
    private Button fanButton;
    private Button pillButton;
    private Button sprayButton;

    private RTLTextMeshPro electricalPasheKoshNumText;
    private RTLTextMeshPro fanNumText;
    private RTLTextMeshPro pillNumText;
    private RTLTextMeshPro sprayNumText;

    private static bool _initialized;
    #endregion

    #region Propertie
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    private void OnEnable()
    {
        if (_initialized)
        {
            
        }
    }

    private void Start()
    {
        
        electricalPasheKoshButton = electricalPasheKosh.GetComponentInChildren<Button>();
        fanButton = fan.GetComponentInChildren<Button>();
        pillButton = pill.GetComponentInChildren<Button>();
        sprayButton = spray.GetComponentInChildren<Button>();

        electricalPasheKoshNumText = electricalPasheKosh.GetComponentInChildren<RTLTextMeshPro>();
        fanNumText = fan.GetComponentInChildren<RTLTextMeshPro>();
        pillNumText = pill.GetComponentInChildren<RTLTextMeshPro>();
        sprayNumText = spray.GetComponentInChildren<RTLTextMeshPro>();

        _initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    #endregion

    #region Methods
    #endregion
}
