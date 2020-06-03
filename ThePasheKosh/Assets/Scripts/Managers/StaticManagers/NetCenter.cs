using UnityEngine;
using System;
using System.Collections.Generic;

public static class NetCenter
{
    static HelperWebRequestHandler webHandler;

    public static void GetData(string url, HttpMethods method, Action<Response> responseEvent = null, WWWForm form = null, string BodyData = null,
                                            Dictionary<string, string> headers = null)
    {
        webHandler.SendWebCoroutine(url, HttpMethods.get, responseEvent, form, BodyData, headers);
    }

    

    public static void InitializeNetCenter()
    {
        webHandler = new HelperWebRequestHandler();
    }

}//EndClasss/SadeQ



