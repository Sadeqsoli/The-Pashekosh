using RTLTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PowerupStruct : MonoBehaviour
{
    [SerializeField] RTLTextMeshPro PU_LevelTXT;
    [SerializeField] RTLTextMeshPro PU_CurrentPriceTXT;
    [SerializeField] Button LevelUpButton;
    [SerializeField] GameObject NoMoneyLock;


    public void GetPU_LevelAndPrice(PowerUpType powerUp)
    {
        PU_LevelTXT.text = PowerupRepo.GetPowerupLevel(powerUp).ToString() ;
        PU_CurrentPriceTXT.text = PowerupRepo.GetPowerupCurrentPrice(powerUp).ToString();
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

}//EndClassss
