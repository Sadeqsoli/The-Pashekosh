using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToastBuilder : MonoBehaviour
{
    [SerializeField] Image _ToastBack;
    [SerializeField] ToastOBJ _ToastOBJ;

    List<ToastOBJ> toastOBJs = new List<ToastOBJ>();
    const int FirstToastsCount = 10;

    public void SendToast(string toast, Transform toastTr)
    {
        ToastOBJ toastOBJ = Instantiate(_ToastOBJ);
        toastOBJ.SetText(toast);
        toastOBJ.transform.SetParent(toastTr);
        toastOBJ.transform.Scaler(TTScale.ShakeIt,
            () => toastOBJ.transform.Scaler(TTScale.ScaleDown));
        
    }

    public void SendToast(string toast, Transform toastTr, float endValue = 1f)
    {
        _ToastBack.color = new Color(_ToastBack.color.r, _ToastBack.color.g, _ToastBack.color.b, 0f);
        _ToastBack.Imager(TTIColoring.IMGFadeIn, endValue, () =>
          {
              ToastOBJ toastOBJ = Instantiate(_ToastOBJ);
              toastOBJ.SetText(toast);
              toastOBJ.transform.SetParent(toastTr);
              toastOBJ.transform.Scaler(TTScale.ShakeIt,
                  () => toastOBJ.transform.Scaler(TTScale.ScaleDown));
          });

    }
    public void SendToast(string toast, Color backColor, Transform toastTr, float endValue = 1f)
    {
        _ToastBack.color = new Color(backColor.r, backColor.g, backColor.b, 0f);
        _ToastBack.Imager(TTIColoring.CustomFadeIn, endValue, () =>
         {
             ToastOBJ toastOBJ = Instantiate(_ToastOBJ);
             toastOBJ.SetText(toast);
             toastOBJ.transform.SetParent(toastTr);
             toastOBJ.transform.Scaler(TTScale.ShakeIt,
                 () => toastOBJ.transform.Scaler(TTScale.ScaleDown));
         });

    }


    void Awake()
    {
        InitToast();
    }
    void InitToast()
    {
        for (int i = 0; i < FirstToastsCount; i++)
        {
            ToastOBJ toastOBJ = Instantiate(_ToastOBJ);
            toastOBJ.gameObject.SetActive(false);
            toastOBJs.Add(toastOBJ);
        }
    }

}//EndClassss
