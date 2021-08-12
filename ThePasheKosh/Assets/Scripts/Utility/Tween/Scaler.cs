using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    public TTScale ttScale = TTScale.ScaleUp;
    void Start()
    {
        transform.Scaler(ttScale);
    }

}//EndClasssss
