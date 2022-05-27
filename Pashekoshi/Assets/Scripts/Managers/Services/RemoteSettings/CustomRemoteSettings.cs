using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomRemoteSettings : MonoBehaviour
{
    public string ColorHex
    {
        get { return _colorHex;}
        set
        {
            Color parsedColor;
           if (ColorUtility.TryParseHtmlString(value, out parsedColor))
            {
                _colorHex = value;
                Renderer renderer = GetComponent<Renderer>();
                renderer.material.SetColor("_Color", parsedColor);
            }
        }
    }
    string _colorHex = "";
}
