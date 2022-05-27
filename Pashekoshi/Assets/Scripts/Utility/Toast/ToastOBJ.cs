using System.Collections;
using System.Collections.Generic;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToastOBJ : MonoBehaviour
{
    [SerializeField] RTLTextMeshPro _ToastTXT;
    float expireTime = 2f;
    public void SetText(string toast)
    {
        _ToastTXT.text = toast;
    }
    IEnumerator Start()
    {
        gameObject.transform.Mover(TTMove.Move, gameObject.transform.localPosition + Vector3.one);
        yield return new WaitForSecondsRealtime(expireTime);
        gameObject.SetActive(false);
    }


}//EndClasssss
