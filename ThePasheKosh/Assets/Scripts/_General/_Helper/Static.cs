using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static<T> : MonoBehaviour where T : Static<T>
{
    static T _instance;
    public static T Instance
    {
        get
        {
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
        }
    }


    

}
