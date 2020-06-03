using System.IO;
using UnityEngine;
using System.Collections.Generic;


public class HelperStreamReader
{
    #region Fields
    List<string[]> linked_WS;
    #endregion


    #region Properties
    public List<string[]> Linked_WS { get { return linked_WS; } }

    #endregion

    #region Public Methods
    public void CSVFileReader(string pathFile)
    {
        string PathName = Path.Combine(Application.streamingAssetsPath, pathFile);
        StreamReader reader = new StreamReader(PathName);
        try
        {
            //input = File.OpenText(PathName);

            string allRecords = reader.ReadToEnd();
            linked_WS = ReadEveryConversationLine(allRecords);
        }
        catch
        {

        }
        finally
        {
            if (reader != null)
            {
                //EditorUtility.RevealInFinder(PathName);
                reader.Close();
            }
        }
    }
    #endregion



    #region Private Methods
    private List<string[]> CSVFileUpdater(string pathFile, string allRecords, int lineToEdit)
    {
        List<string[]> targetList = new List<string[]>();
        string[] allLines = allRecords.Split('\n');
        

        for (int i = 0; i < allLines.Length; i++)
        {
            string[] row = allLines[i].Split('/');

            targetList.Add(row);
        }
        return targetList;
    }

    List<string[]> ReadEveryConversationLine(string allRecords)
    {
        List<string[]> targetList = new List<string[]>();
        string[] allLines = allRecords.Split('\n');

        for (int i = 0; i < allLines.Length; i++)
        {
            string[] row = allLines[i].Split('/');
            //Debug.Log(row[0] + " " + row[1]+ " " + row[2]);
            targetList.Add(row);
        }
        return targetList;
    }
    #endregion

}//EndClasss/SadeQ

