using RTLTMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PULock : MonoBehaviour
{


    [SerializeField] RTLTextMeshPro DisplayFeeTXT;
    [SerializeField] Button PULockButton;

    void Start()
    {
        PULockButton = GetComponent<Button>();
    }

    public void SetDisplayFee(string priceText)
    {
        DisplayFeeTXT.text = priceText;
    }

    public void ChangeListener(UnityAction unityAction)
    {
        PULockButton.onClick.RemoveAllListeners();
        PULockButton.onClick.AddListener(unityAction);
    }


}//EndClassss
