using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerupStruct : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PU_LevelTXT;
    [SerializeField] TextMeshProUGUI PU_CurrentPriceTXT;
    [SerializeField] Button LevelUpButton;
    [SerializeField] GameObject NoMoneyLock;


    public void GetPU_LevelAndPrice(int levelNumber, int price)
    {
        PU_LevelTXT.text = levelNumber.ToString();
        PU_CurrentPriceTXT.text = price.ToString();
    }

    public void LockPowerUp(bool isLock)
    {
        NoMoneyLock.SetActive(!isLock);
    }
    public void AddNewListener(UnityAction unityAction)
    {
        LevelUpButton.onClick.RemoveAllListeners();
        LevelUpButton.onClick.AddListener(unityAction);
    }

}
