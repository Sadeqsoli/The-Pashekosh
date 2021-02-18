using RTLTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Locker : MonoBehaviour
{
    [SerializeField] RTLTextMeshPro DisplayFeeTXT;
    [SerializeField] Button LockerButton;



    public void SetDisplayFee(string priceText)
    {
        DisplayFeeTXT.text = priceText;
    }

    public void ChangeListener(UnityAction unityAction)
    {
        LockerButton.onClick.RemoveAllListeners();
        LockerButton.onClick.AddListener(unityAction);
    }



}//EndClasss
