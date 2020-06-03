using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class HelperGeneral
{

    public static T FindObject<T>()
    {

        List<T> ss = default(List<T>);
        T s = default(T);
        ss = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<T>().ToList();

        foreach (var sss in ss)
        {
            s = sss;
            return s;
        }
        return s;
    }

    public static List<T> FindObjectsList<T>()
    {
        List<T> ss = default(List<T>);
        ss = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<T>().ToList();
        return ss;
    }

    public static T[] FindObjectsArray<T>() 
    {
        List<T> ss = default(List<T>);
        ss = GameObject.FindObjectsOfType<MonoBehaviour>().OfType<T>().ToList();
        T[] myarray =new  T[ss.Count()];
        for (int i = 0; i < ss.Count(); i++)
        {
            myarray[i] = ss[i];
        }
        return myarray;
    }

}//EndClassss/SadeQ
