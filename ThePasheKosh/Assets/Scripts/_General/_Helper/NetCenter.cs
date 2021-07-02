using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;

public class NetCenter : Singleton<NetCenter>
{

    public T[] GetArrayOfObjects<T>(string baseURL)
    {
        T[] typeOfSomethingAsArray = default;
        StartCoroutine(GetRequest(baseURL, (UnityWebRequest uwr) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log($"{uwr.error}: {uwr.downloadHandler.text}");
            }
            else
            {
                typeOfSomethingAsArray = JsonConvert.DeserializeObject<T[]>(uwr.downloadHandler.text);

                foreach (T singleType in typeOfSomethingAsArray)
                {
                    //do Something
                }
            }
        }));
        return typeOfSomethingAsArray;
    }

    public void GetListOfObjects<T>(string url, UnityAction<List<T>> OnCompleteAction = null, UnityAction On401Error = null)
    {
        StartCoroutine(GetRequest(url, (UnityWebRequest uwr) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log($"{uwr.error}: {uwr.downloadHandler.text}");
            }
            else
            {
                var ListOfObjects = JsonConvert.DeserializeObject<List<T>>(uwr.downloadHandler.text);

                foreach (T singleType in ListOfObjects)
                {
                    //do Something
                }
                OnCompleteAction?.Invoke(ListOfObjects);
            }
        }));
    }

    public T GetSingleObject<T>(string baseURL)
    {
        T typeOfSomething = default;
        StartCoroutine(GetRequest(baseURL, (UnityWebRequest uwr) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log($"{uwr.error}: {uwr.downloadHandler.text}");
            }
            else
            {
                typeOfSomething = JsonConvert.DeserializeObject<T>(uwr.downloadHandler.text);


                //do Something with result => in this case typeOfSomething

            }
        }));
        return typeOfSomething;
    }
    public void GetSingleObject<T>(string url, UnityAction<T> OnCompleteAction = null, UnityAction On401Error = null)
    {
        StartCoroutine(GetRequest(url, (UnityWebRequest uwr) =>
        {
            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log($"{uwr.error}: {uwr.downloadHandler.text}");
                if (uwr.responseCode == 401)
                {
                    On401Error?.Invoke();
                }
            }
            else
            {
                var _object = JsonConvert.DeserializeObject<T>(uwr.downloadHandler.text);
                OnCompleteAction?.Invoke(_object);
                Debug.Log("Errorless!");
            }
        }));
    }


    //For Downloading to persistent data
    public void DownloadFileToDisk(string Serverurl, string localUrl)
    {
        StartCoroutine(DownloadFile(Serverurl, localUrl));
    }
    //For Downloading to persistent data
    public void DownloadImageToDisk(string Serverurl, string localUrl)
    {
        StartCoroutine(ImageRequest(Serverurl, (UnityWebRequest req) =>
       {
           if (req.isNetworkError || req.isHttpError)
           {
               Debug.Log($"{req.error}: {req.downloadHandler.text}");
           }
           else
           {
               if (!Directory.Exists(localUrl))
               {
                   Directory.CreateDirectory(Path.GetDirectoryName(localUrl));
               }
               File.WriteAllBytes(localUrl, req.downloadHandler.data);
           }
       }));
    }

    public void DownloadSoundToDisk(string Serverurl, string localUrl, AudioType audioType = AudioType.MPEG)
    {
        StartCoroutine(SoundRequest(Serverurl, audioType, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }
            else
            {
                if (!Directory.Exists(localUrl))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(localUrl));
                }
                File.WriteAllBytes(localUrl, req.downloadHandler.data);
            }
        }));
    }



    //For UI Systems
    public void DownloadVideoFromDisk(string localUrl, Image image)
    {
        StartCoroutine(ImageRequest("file://" + localUrl, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }
            else
            {
                // Get the texture out using a helper downloadhandler
                Texture2D texture = DownloadHandlerTexture.GetContent(req);
                // Save it into the Image UI's sprite
                Sprite sprite = texture.ConvertToSprite();
                image.sprite = sprite;
            }
        }));
    }

    //For UI Systems
    public void DownloadImageFromDisk(string localUrl, Image image)
    {
        StartCoroutine(ImageRequest("file://" + localUrl, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }
            else
            {
                // Get the texture out using a helper downloadhandler
                Texture2D texture = DownloadHandlerTexture.GetContent(req);
                // Save it into the Image UI's sprite
                Sprite sprite = texture.ConvertToSprite();
                image.sprite = sprite;
            }
        }));
    }

    //For Sprite Renderer
    public void DownloadImageFromDisk(string localUrl, SpriteRenderer spriteRenderer, float ppu = 190f)
    {
        StartCoroutine(ImageRequest("file://" + localUrl, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }
            else
            {
                // Get the texture out using a helper downloadhandler
                Texture2D texture = DownloadHandlerTexture.GetContent(req);
                // Save it into the Image UI's sprite
                Sprite sprite = texture.ConvertToSprite(ppu);
                if (sprite != null)
                    spriteRenderer.sprite = sprite;
            }
        }));
    }



    //Returning A Sprite or sound after download.
    public void DownloadImage(string localUrl, UnityAction<Sprite> unityAction_SP)
    {
        StartCoroutine(ImageRequest("file://" + localUrl, (UnityWebRequest req) =>
        {
            if (req.isNetworkError || req.isHttpError)
            {
                Debug.Log($"{req.error}: {req.downloadHandler.text}");
            }
            else
            {
                // Get the texture out using a helper downloadhandler
                Texture2D texture = DownloadHandlerTexture.GetContent(req);
                // Save it into the Image UI's sprite
                Sprite sprite = texture.ConvertToSprite();
                if (sprite != null)
                    unityAction_SP.Invoke(sprite);
            }
        }));
    }
    public void DownloadSound(string localUrl, UnityAction<AudioClip> unityAction_AC, AudioType audioType = AudioType.MPEG)
    {
        StartCoroutine(SoundRequest("file://" + localUrl, audioType, (UnityWebRequest req) =>
         {
             if (req.isNetworkError || req.isHttpError)
             {
                 Debug.Log($"{req.error}: {req.downloadHandler.text}");
             }
             else
             {
                 // Get the sound out using a helper class
                 AudioClip clip = DownloadHandlerAudioClip.GetContent(req);
                 // Load the clip into our audio source and play
                 if (clip != null)
                     unityAction_AC?.Invoke(clip);
             }
         }));
    }



    public void SaveTextureOnDisk(string localUrl, Texture2D texture)
    {
        byte[] mediaBytes = texture.EncodeToPNG();
        if (!Directory.Exists(localUrl))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(localUrl));
        }
        File.WriteAllBytes(localUrl, mediaBytes);
        //Debug.Log("Saved at " + localUrl);
    }


    IEnumerator SoundRequest(string localUrl, AudioType audioType, Action<UnityWebRequest> soundCallback)
    {
        // Note, we try to download an OGGVORBIS (ogg) file because Windows doesn't support
        // MPEG readily. If you're on a mac, you can try MPEG (mp3)
        using (UnityWebRequest req = UnityWebRequestMultimedia.GetAudioClip(localUrl, audioType))
        {
            yield return req.SendWebRequest();
            soundCallback(req);
        }
    }
    IEnumerator ImageRequest(string localUrl, Action<UnityWebRequest> imageCallback)
    {
        using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(localUrl))
        {
            yield return req.SendWebRequest();
            while (Application.internetReachability == NetworkReachability.NotReachable)
            {
                yield return null;
            }
            imageCallback(req);
        }
    }
    IEnumerator VideoRequest(string localUrl, Action<UnityWebRequest> imageCallback)
    {
        using (UnityWebRequest req = UnityWebRequestTexture.GetTexture(localUrl))
        {
            yield return req.SendWebRequest();
            while (Application.internetReachability == NetworkReachability.NotReachable)
            {
                yield return null;
            }
            imageCallback(req);
        }
    }
    IEnumerator GetRequest(string localUrl, Action<UnityWebRequest> apiCallback)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(localUrl))
        {

            // Send the request and wait for a response
            yield return uwr.SendWebRequest();

            apiCallback(uwr);
        }
    }

    IEnumerator DownloadFile(string serverUrl, string localUrl)
    {
        var uwr = new UnityWebRequest(serverUrl, UnityWebRequest.kHttpVerbGET);

        uwr.downloadHandler = new DownloadHandlerFile(localUrl);

        StartCoroutine(ShowDownloadProgress(uwr));

        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError || uwr.isHttpError)
        {
            Debug.LogError(uwr.error);
        }
        else
        {
            //int dataLength = uwr.downloadHandler.data.Length;
            //string ByteLength = STR.SizeSuffix((long)dataLength);

            //FileSizeTXT.text = "Current File Size: " + ByteLength;
            //if (!Directory.Exists(localUrl))
            //{
            //    Directory.CreateDirectory(Path.GetDirectoryName(localUrl));
            //}
            //File.WriteAllBytes(localUrl, uwr.downloadHandler.data);
            //Debug.Log("File successfully downloaded and saved to " + localUrl);

        }
    }
    IEnumerator ShowDownloadProgress(UnityWebRequest uwr)
    {
        while (!uwr.isDone)
        {
            //downloadDataProgress = uwr.downloadProgress * 100;
            //IndividualProgressIMG.fillAmount = uwr.downloadProgress;
            //IndividualProgressTXT.text = "%" + downloadDataProgress.ToString("###");
            //if (downloadDataProgress <= 0)
            //    IndividualProgressTXT.text = "%0";
            //Debug.Log("Progress " + uwr.downloadProgress);
            while (Application.internetReachability == NetworkReachability.NotReachable)
            {
                yield return null;
            }
            yield return new WaitForSeconds(.01f);
        }
        //Debug.Log("Done");
    }




}//EndClassss
