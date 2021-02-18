using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public static class DataRepo
{
    const string JSONEXTENSION = ".json";


    #region Initializing



    #endregion


    #region Helper 

    static string RemoveFileExtension(string saveFileName)
    {
        string savePathFile = Path.Combine(Application.persistentDataPath, saveFileName, JSONEXTENSION);

        if (savePathFile.Length >= JSONEXTENSION.Length)
        {
            //If file extension exist, remove it.
            if (savePathFile.ToLower().Substring(savePathFile.Length - JSONEXTENSION.Length, JSONEXTENSION.Length) == JSONEXTENSION.ToLower())
            {
                return savePathFile.Substring(0, savePathFile.Length - JSONEXTENSION.Length);
            }
            else
            {
                //File extension doesn't exist.
                return savePathFile;
            }
        }
        else
        {
            //Path isn't long enough to contain file extension.
            return savePathFile;
        }
    }
    static string RemoveLeadingDirectorySeparator(string savePathFile)
    {
        //Remove directory separate character if it exist on the first character.
        if (char.Parse(savePathFile.Substring(0, 1)) == Path.DirectorySeparatorChar || char.Parse(savePathFile.Substring(0, 1)) == Path.AltDirectorySeparatorChar)
        {
            return savePathFile.Substring(1);
        }
        else
        {
            return savePathFile;
        }
    }

    #endregion



    #region <<<<<<Persistent Data Path>>>>> Persistant Data
    public static void SaveListOfDataFile<T>(string saveFileName, List<T> typeOfObject)
    {
        string savePathFile = Path.Combine(Application.persistentDataPath, saveFileName, JSONEXTENSION);
        string json = JsonConvert.SerializeObject(typeOfObject);

        File.WriteAllText(savePathFile, json);

    }
    public static List<T> RetriveListOfDataFile<T>(string saveFileName)
    {
        string savePathFile = Path.Combine(Application.persistentDataPath, saveFileName, JSONEXTENSION);
        if (File.Exists(savePathFile))
        {
            string json = File.ReadAllText(savePathFile);

            return JsonConvert.DeserializeObject<List<T>>(json).ToList();
        }
        Debug.LogWarning("Return stringResultList -> result text is empty.");
        return new List<T>();
    }



    public static void SaveDataFile<T>(string saveFileName, T typeOfObject)
    {
        string savePathFile = Path.Combine(Application.persistentDataPath, saveFileName, JSONEXTENSION);
        string json = JsonConvert.SerializeObject(typeOfObject);

        File.WriteAllText(savePathFile, json);

    }

    public static T RetriveDataFile<T>(string saveFileName)
    {
        string savePathFile = Path.Combine(Application.persistentDataPath, saveFileName, JSONEXTENSION);
        if (File.Exists(savePathFile))
        {
            string json = File.ReadAllText(savePathFile);

            return JsonConvert.DeserializeObject<T>(json);
        }
        Debug.LogWarning("Return stringResult -> result text is empty.");
        return default(T);
    }

    #endregion







    #region <<<<<<Playerprefs>>>>> Persistant Data
    public static List<T> RetriveListOfData<T>(string repoKey)
    {
        string stringResultList = PlayerPrefs.GetString(repoKey);

        if (stringResultList.Length != 0)
        {
            return JsonConvert.DeserializeObject<List<T>>(stringResultList).ToList();
        }
        else
        {
            Debug.LogWarning("Return stringResultList -> result text is empty.");
            return new List<T>();
        }
    }
    public static void SaveListOfData<T>(string repoKey, List<T> typeOfObject)
    {
        PlayerPrefs.SetString(repoKey, JsonConvert.SerializeObject(typeOfObject));
        PlayerPrefs.Save();
    }


    public static T RetriveData<T>(string repoKey)
    {
        string stringResult = PlayerPrefs.GetString(repoKey);

        if (stringResult != null)
        {
            return JsonConvert.DeserializeObject<T>(stringResult);
        }
        else
        {
            Debug.LogWarning("Return stringResult -> result text is empty.");
            return default(T);
        }
    }
    public static void SaveData<T>(string repoKey, T typeOfObject)
    {
        PlayerPrefs.SetString(repoKey, JsonConvert.SerializeObject(typeOfObject));
        PlayerPrefs.Save();

    }
    #endregion
}
