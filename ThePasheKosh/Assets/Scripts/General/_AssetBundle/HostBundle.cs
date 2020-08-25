using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class HostBundle : MonoBehaviour
{
    #region Properties


    #endregion

    #region Fields
    [SerializeField] string SaveAddress;
    [SerializeField] Text txtstatus;
    [SerializeField] Text txtLocation;
    #endregion

    #region Public Methods
    public void Loader_Assets(string Asseturl)
    {
        if (File.Exists(Application.persistentDataPath + "/" + SaveAddress + "/Asset"))
            StartCoroutine(LoadAsset());
        else
            StartCoroutine(Download_Write(Asseturl, "Asset"));
    }
    
    public void Loader_Scene(string SceneUrl)
    {
        if (File.Exists(Application.persistentDataPath + "/" + SaveAddress + "/scene"))
            StartCoroutine(Load_Scene());
        else
            StartCoroutine(Download_Write(SceneUrl, "scene"));
    }
   

    public void Delete(string DlAddress)
    {
        if (File.Exists(Application.persistentDataPath + "/" + SaveAddress + "/" + DlAddress))
        {
            File.Delete(Application.persistentDataPath + "/" + SaveAddress + "/" + DlAddress);
            print("Deleted " + Application.persistentDataPath + "/" + SaveAddress + "/" + DlAddress);
            txtstatus.text = "Deleted " + Application.persistentDataPath + "/" + SaveAddress + "/" + DlAddress;
        }
        else
            print("Cant delete");
            txtstatus.text = "Cant delete " + Application.persistentDataPath + "/" + SaveAddress + "/" + DlAddress;
    }
    


    #endregion


    #region Private Methods
    void Start()
    {
        txtLocation.text = Application.persistentDataPath;
    }//Startttttt

    IEnumerator LoadAsset()
    {
        UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle("file:///" + Application.persistentDataPath + "/" + SaveAddress + "/Asset");
        yield return webRequest.SendWebRequest();
        if (!string.IsNullOrEmpty(webRequest.error))
        {
            Debug.LogError(webRequest.error);
            txtstatus.text = webRequest.error;
            yield break;
        }
        else
        {
            print("Loading");
            txtstatus.text = "Loading";
            AssetBundle asset = DownloadHandlerAssetBundle.GetContent(webRequest);
            string[] All_Names = asset.GetAllAssetNames();
            foreach (string name in All_Names)
            {
                if (name != null)
                {
                    GameObject a = (GameObject)asset.LoadAsset(name);
                    Instantiate(a);
                    print("ObjectName= " + name);
                    txtstatus.text = "ObjectName= " + name;
                }

            }
        }
    }

    

    IEnumerator Load_Scene()
    {
        UnityWebRequest webRequest = UnityWebRequestAssetBundle.GetAssetBundle("file:///" + Application.persistentDataPath + "/" + SaveAddress + "/scene");
        {
            yield return webRequest.SendWebRequest();
            if (!string.IsNullOrEmpty(webRequest.error))
            {
                Debug.LogError(webRequest.error);
                yield break;
            }
            AssetBundle asset = DownloadHandlerAssetBundle.GetContent(webRequest);
            string[] scenes = asset.GetAllScenePaths();
            foreach (string scenename in scenes)
            {
                print("scene= " + scenename);
                txtstatus.text = "scene= " + scenename;
                UnityEngine.SceneManagement.SceneManager.LoadScene(scenename);

            }

        }
    }
    
    IEnumerator Download_Write(string DownloadURL, string SaveName)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(DownloadURL))
        {
            yield return webRequest;
            if (!string.IsNullOrEmpty(webRequest.error))
            {
                Debug.LogError(webRequest.error);
                yield break;
            }
            print("Download");
            txtstatus.text = "Download";
            //Create Directory
            Directory.CreateDirectory(Application.persistentDataPath + "/" + SaveAddress);
            //Save Assets
            File.WriteAllBytes(Application.persistentDataPath + "/" + SaveAddress + "/" + SaveName, webRequest.downloadHandler.data);
        }
    }
    
    
    void Update()
    {


    }//Updateeeee
    #endregion
}//EndClasssss/SadeQ
