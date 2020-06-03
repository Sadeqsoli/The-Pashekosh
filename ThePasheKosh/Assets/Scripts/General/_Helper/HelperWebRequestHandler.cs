using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class HelperWebRequestHandler : MonoBehaviour
{
    static HelperWebRequestHandler mInstance = null;
    static HelperWebRequestHandler instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = GameObject.FindObjectOfType(typeof(HelperWebRequestHandler)) as HelperWebRequestHandler;

                if (mInstance == null)
                {
                    mInstance = new GameObject("HelperWebRequestHandler").AddComponent<HelperWebRequestHandler>();
                }
            }
            return mInstance;
        }
    }


    public void SendWebCoroutine(string url, HttpMethods method, Action<Response> responseEvent = null, WWWForm form = null, string BodyData = null,
                                            Dictionary<string, string> headers = null)
    {
        HelperWebRequestHandler.DoCoroutine(SendWebRequest(url, HttpMethods.get, responseEvent, form, BodyData, headers));
    }
    private IEnumerator SendWebRequest(string url, HttpMethods method, Action<Response> responseEvent = null, WWWForm form = null, string BodyData = null,
                                            Dictionary<string, string> headers = null)
    {

        UnityWebRequest www = null;
        switch (method)
        {
            case HttpMethods.get:
                www = UnityWebRequest.Get(url);
                break;
            case HttpMethods.post:
                www = UnityWebRequest.Post(url, form);
                break;
            case HttpMethods.delete:
                www = UnityWebRequest.Delete(url);
                break;
            case HttpMethods.head:
                www = UnityWebRequest.Head(url);
                break;
            case HttpMethods.put:
                www = UnityWebRequest.Put(url, BodyData);
                break;
        }
        if (headers != null)
        {
            foreach (var item in headers)
            {
                www.SetRequestHeader(item.Key, item.Value);
            }
        }

        yield return www.SendWebRequest();




        Response r = new Response(www.downloadHandler.text, www.GetResponseHeaders(), www.responseCode, www.error, www.isNetworkError);
        responseEvent.Invoke(r);
        www.Dispose();
    }

    IEnumerator Perform(IEnumerator coroutine)
    {
        yield return StartCoroutine(coroutine);
        Die();
    }

    public static void DoCoroutine(IEnumerator coroutine)
    {
        instance.StartCoroutine(instance.Perform(coroutine)); //this will launch the coroutine on our instance
    }

    void Die()
    {
        mInstance = null;
        Destroy(gameObject);
    }

    void OnApplicationQuit()
    {
        mInstance = null;
    }


}//EndClasssss/SadeQ






public enum HttpMethods
{
    get, post, delete, head, put
}

public class Response
{
    public Response(string Message, Dictionary<string, string> ResponseHeaders, long MessageCode, string ErrorBody, bool IsError)
    {
        isError = IsError;
        message = Message;
        responseHeaders = ResponseHeaders;
        messageCode = MessageCode;
        errorBody = ErrorBody;
    }

    public string message;
    public Dictionary<string, string> responseHeaders;
    public long messageCode;
    public string errorBody;
    public bool isError;
}