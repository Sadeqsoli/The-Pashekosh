using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using UnityEngine;


public class HelperDatabaseLoader : MonoBehaviour
{
    #region Properties
    //public Property  Any Database(JSON)
    public TestArray TestArray { get { return _testArray; } }
    #endregion



    #region Fields
    /// <summary>
    /// Collection of Conversations.
    /// </summary>
    TestArray _testArray = new TestArray();

    /// <summary>
    /// Extension of the database files.
    /// </summary>
    private const string FILE_EXTENSION = @".json";
    #endregion

    #region Public Methods

    public TestArray ReturnDatabase(string databaseName)
    {
         _testArray = ReturnDatabase<TestArray>(databaseName);
        return _testArray;
    }

    #endregion


    #region Private Methods

    /// <summary>
    /// Removes the default file extension from path.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private string RemoveFileExtension(string path)
    {
        if (path.Length >= FILE_EXTENSION.Length)
        {
            //If file extension exist, remove it.
            if (path.ToLower().Substring(path.Length - FILE_EXTENSION.Length, FILE_EXTENSION.Length) == FILE_EXTENSION.ToLower())
                return path.Substring(0, path.Length - FILE_EXTENSION.Length);
            //File extension doesn't exist.
            else
                return path;
        }
        //Path isn't long enough to contain file extension.
        else
        {
            return path;
        }
    }

    /// <summary>
    /// Removes the directory separator if at the begining of path.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private string RemoveLeadingDirectorySeparator(string path)
    {
        //Remove directory separate character if it exist on the first character.
        if (char.Parse(path.Substring(0, 1)) == Path.DirectorySeparatorChar || char.Parse(path.Substring(0, 1)) == Path.AltDirectorySeparatorChar)
            return path.Substring(1);
        else
            return path;
    }

    /// <summary>
    /// Returns string result of a text file from Resources.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private string ReturnFileResource(string path)
    {
        //Remove default file extension and format the path to the platform.
        path = RemoveFileExtension(path);
        path = RemoveLeadingDirectorySeparator(path);

        if (path == string.Empty)
        {
            Debug.LogError("ReturnFileResource -> path is empty.");
            return string.Empty;
        }

        //Try to load text from file path.
        TextAsset textAsset = Resources.Load(path) as TextAsset;

        if (textAsset != null)
            return textAsset.text;
        else
            return string.Empty;
    }

    /// <summary>
    /// Returns a database at the file path.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    private TestArray ReturnDatabase<T>(string path)
    {
        string result = ReturnFileResource(path);

        if (result.Length != 0)
        {
            return JsonConvert.DeserializeObject<TestArray>(result)/*.ToList()*/;
        }
        else
        {
            Debug.LogWarning("ReturnDatabase -> result text is empty.");
            return new TestArray();
        }
    }


    #endregion

}//EndClasss/SadeQ
