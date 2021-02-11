using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToastBuilder : MonoBehaviour
{
    [SerializeField] RTLTextMeshPro _ToastTXT;
    [SerializeField] Image _ToastBodyIMG;
    Animator anim;

    public void SendToast(string toast)
    {
        _ToastTXT.text = toast;
        gameObject.SetActive(true);
    }
    public void SendToast(string toast, Color textColor)
    {
        _ToastTXT.text = toast;
        _ToastTXT.color = textColor;
        gameObject.SetActive(true);
    }
    public void SendToast(string toast, Color textColor, Color bodyColor)
    {
        _ToastBodyIMG.color = bodyColor;
        _ToastTXT.text = toast;
        _ToastTXT.color = textColor;
        gameObject.SetActive(true);
    }

    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void OnEnable()
    {
        anim.SetTrigger("toast");
    }


    void SetToastOFF()
    {
        gameObject.SetActive(false);
    }

}
