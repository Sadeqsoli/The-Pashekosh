using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System;
using System.Text;

public class HelperStreamWriterReader
{
    #region Fields
    List<string[]> linked_WS;
    char lineSeperater = '\n'; // It defines line seperate character
    char fieldSeperator = '/'; // It defines field seperate chracter
    #endregion


    #region Properties
    public List<string[]> Linked_WS { get { return linked_WS; } set { linked_WS = value; } }


    #endregion



    #region Reader Methods
    public void CSVFileReader(string pathFile)
    {
        string PathName = Path.Combine(Application.streamingAssetsPath, pathFile);
        StreamReader reader = new StreamReader(PathName);
        try
        {
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
                reader.Close();

            }
        }
    }

    List<string[]> ReadEveryConversationLine(string allRecords)
    {
        List<string[]> targetList = new List<string[]>();
        string[] allLines = allRecords.Split(lineSeperater);

        for (int i = 0; i < allLines.Length; i++)
        {
            string[] row = allLines[i].Split(fieldSeperator);
            //Debug.Log(row[0] + " " + row[1]+ " " + row[2]);
            targetList.Add(row);
        }
        return targetList;
    }


    #endregion



    #region Writer Methods
    public void CSVFileUpdater(string pathFile, string newLine, int lineToEdit)
    {
        string PathName = Path.Combine(Application.streamingAssetsPath, pathFile);
        StreamWriter writer = new StreamWriter(PathName, false);
        try
        {
            string[] allLines = File.ReadAllLines(PathName);
            for (int i = 0; i < allLines.Length; i++)
            {
                string[] elements = allLines[i].Split(lineSeperater);
                if(newLine.Contains(elements[lineToEdit]))
                elements[lineToEdit] = newLine;
                Debug.Log(elements[lineToEdit]);
                writer.WriteLine(elements[lineToEdit]);
            }
            
        }
        catch (Exception e)
        {
            throw new ApplicationException("There is an Exception: " + e);
        }
        finally
        {
            writer.Close();
        }

    }

    public void CSVFileWriter(string pathFile, string dialogue, string[] linkedWords)
    {
        string PathName = Path.Combine(Application.streamingAssetsPath, pathFile);

        StreamWriter output = File.AppendText(PathName);
        try
        {
            string ArrayWords = "";
            for (int i = 0; i < linkedWords.Length; i++)
            {
                ArrayWords += linkedWords[i] + fieldSeperator;
            }
            int lastSlash = ArrayWords.LastIndexOf(fieldSeperator);
            string slashSeperatedWords = ArrayWords.Remove(lastSlash);

            output.WriteLine(dialogue + fieldSeperator + slashSeperatedWords);
        }
        catch (Exception e)
        {
            throw new ApplicationException("There is an Exception: " + e);
        }
        finally
        {
            if (output != null)
            {
                //EditorUtility.RevealInFinder(PathName);
                output.Close();

            }
        }

    }
    #endregion

    
}//EndClasss/SadeQ

