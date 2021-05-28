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

    public static string ElectricalPasheKosh { get; } = "ElectricalPasheKosh";
    public static string Fan { get; } = "Fan";
    public static string Pill { get; } = "Pill";
    public static string Spray { get; } = "Spray";

    public GameObject electricalPasheKosh;
    public GameObject fan;
    public GameObject pill;
    public GameObject spray;

    public PowerUpsManager powerUpsManager;

    private Button electricalPasheKoshButton;
    private Button fanButton;
    private Button pillButton;
    private Button sprayButton;

    private RTLTextMeshPro electricalPasheKoshNumText;
    private RTLTextMeshPro fanNumText;
    private RTLTextMeshPro pillNumText;
    private RTLTextMeshPro sprayNumText;

    private static int electricalPkNum, fanNum, pillNum, sprayNum;

    private static bool _initialized;
    #endregion

    #region Propertie
    #endregion

    #region Unity Methods

    // Start is called before the first frame update
    private void OnEnable()
    {
        InitializePowerUps();
        electricalPasheKoshButton.onClick.AddListener(() => powerUpsManager.UseElectricalPasheKosh());
        fanButton.onClick.AddListener(() => powerUpsManager.UseFan());
        pillButton.onClick.AddListener(() => powerUpsManager.UsePill());
        sprayButton.onClick.AddListener(() => powerUpsManager.UseSpray());
    }

    // Update is called once per frame
    void Update()
    {
        electricalPasheKoshNumText.text = electricalPkNum.ToString();
        fanNumText.text = fanNum.ToString();
        pillNumText.text = pillNum.ToString();
        sprayNumText.text = sprayNum.ToString();
    }

    #endregion

    #region Methods

    public static void UpdatePowerUp(int electricalPkNumber, int fanNumber, int pillNumber, int sprayNumber)
    {
        electricalPkNum = electricalPkNumber;
        fanNum = fanNumber;
        pillNum = pillNumber;
        sprayNum = sprayNumber;
    }

    public static void DecreaseElectricalNum()
    {
        electricalPkNum--;
    }

    public static void DecreaseFanNum()
    {
        fanNum--;
    }

    public static void DecreaseSprayNum()
    {
        sprayNum--;
    }

    public static void DecreasePillNum()
    {
        pillNum--;
    }

    private void InitializePowerUps()
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
    #endregion
}
