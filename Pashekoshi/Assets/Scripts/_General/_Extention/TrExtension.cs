using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrExtension 
{
    public static void SetTransformAsChild(this Transform tr, Transform parent, int index = 0)
    {
        tr.SetParent(parent);
        tr.SetSiblingIndex(index);
        tr.localPosition = Vector3.zero;
        tr.localScale = Vector3.one;
    }
    public static void SetToTop(this Transform tr)
    {
        RectTransform wordTR = (RectTransform)tr.transform;
        wordTR.localPosition = new Vector3(0, 0, wordTR.localPosition.z);
    }





}//EndClassss



