using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum ToastMode{ Short, Long, Permanent }
public class Toast : Singleton<Toast>
{
    [SerializeField] TextMeshProUGUI _ToastTXT;
    [SerializeField] Image _ToastBodyIMG;
    [SerializeField] Button ClosePermanentToastButton;
    [SerializeField] GameObject WaitingPanel;
    Animator anim;


    public void PullUpWaitingPanel()
    {
        WaitingPanel.transform.localScale = Vector3.one;
        WaitingPanel.SetActive(true);
    }

    public void PullDownWaitingPanel()
    {
        WaitingPanel.transform.DOScaleY(0, 1f)
            .SetEase(Ease.InOutExpo)
            .OnStepComplete(()=> {
                WaitingPanel.SetActive(false);
            });
    }


    public void SendToast(string toast, ToastMode toastMode = ToastMode.Short)
    {
        SetAllAnimOff();
        _ToastTXT.text = toast;

        switch (toastMode)
        {
            case ToastMode.Short:
                anim.SetBool("shortToast", true);

                break;
            case ToastMode.Long:
                anim.SetBool("longToast", true);

                break;
            case ToastMode.Permanent:
                anim.SetBool("permanentToast", true);

                break;
        }
       
    }

    public void SendToast(string toast, Color textColor)
    {
        _ToastTXT.text = toast;
        _ToastTXT.color = textColor;
    }
    public void SendToast(string toast, Color textColor, Color bodyColor)
    {
        _ToastBodyIMG.color = bodyColor;
        _ToastTXT.text = toast;
        _ToastTXT.color = textColor;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        ClosePermanentToastButton.onClick.AddListener(SetPermanentToastOFF);
    }


    void SetAllAnimOff()
    {
        anim.SetBool("longToast", false);
        anim.SetBool("shortToast", false);
        anim.SetBool("permanentToast", false);
    }

    void SetShortToastOFF()
    {
        anim.SetBool("shortToast", false);
    }
    void SetLongToastOFF()
    {
        anim.SetBool("longToast", false);
    }
    void SetPermanentToastOFF()
    {
        anim.SetBool("permanentToast", false);
        ClosePermanentToastButton.gameObject.SetActive(false);
    }


}//EndStarcttttt
