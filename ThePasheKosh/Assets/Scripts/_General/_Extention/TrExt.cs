﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrExt : Singleton<TrExt>
{
    WaitForSeconds wait = new WaitForSeconds(0.000000000000001f);

    public static void SetObj_On(GameObject[] gameObjects, int numb)
    {
        int arrayLength = gameObjects.Length;
        for (int i = 0; i < arrayLength; i++)
        {
            if (numb == i)
            {
                if (!gameObjects[i].activeSelf)
                {
                    gameObjects[i].transform.Scaler(TTScale.ScaleUp);
                    //SFXPlayer.Instance.PlaySFX(UIFeedback.Open);
                }
            }
            else
            {
                if (gameObjects[i].activeSelf)
                    gameObjects[i].transform.Scaler(TTScale.ScaleDown, null, 0.5f);
            }
        }
    }


    public static void DestroyAllChildren(Transform tr)
    {
        int childCount = tr.childCount;

        if (childCount > 0)
            for (int i = 0; i < childCount; i++)
            {
                Destroy(tr.GetChild(i).gameObject);
            }
    }
    public static void SetOffAllChildren(Transform tr)
    {
        int childCount = tr.childCount;

        if (childCount > 0)
            for (int i = 0; i < childCount; i++)
            {
                tr.GetChild(i).gameObject.SetActive(false);
            }
    }
    public static void DestroyTargetChild(Transform tr, int numb)
    {
        int childCount = tr.childCount;

        if (childCount > 0)
            for (int i = 0; i < childCount; i++)
            {
                if(i == numb)
                    Destroy(tr.GetChild(i).gameObject);
            }
    }
    public IEnumerator SetOffON(Transform tr)
    {
        int childCount = tr.childCount;

        if (childCount > 0)
            for (int i = 0; i < childCount; i++)
            {
                tr.gameObject.SetActive(false);
                yield return wait;
            }

        if (childCount > 0)
            for (int i = 0; i < childCount; i++)
            {
                tr.gameObject.SetActive(true);
                yield return wait;
            }
    }
    public IEnumerator SetONOff(Transform tr)
    {
        int childCount = tr.childCount;

        if (childCount > 0)
            for (int i = 0; i < childCount; i++)
            {
                tr.gameObject.SetActive(true);
                yield return wait;
            }

        if (childCount > 0)
            for (int i = 0; i < childCount; i++)
            {
                tr.gameObject.SetActive(false);
                yield return wait;
            }
    }

    public IEnumerator SetActiveDeactive(GameObject go)
    {
        go.SetActive(false);
        yield return new WaitForEndOfFrame();
        go.SetActive(true);
    }
    public IEnumerator SetActiveDeactive(Transform tr)
    {
        tr.gameObject.SetActive(false);
        yield return new WaitForEndOfFrame();
        tr.gameObject.SetActive(true);
    }


}//EndClasss
