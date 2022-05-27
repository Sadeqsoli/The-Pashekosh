using System.Collections.Generic;
using UnityEngine;

public static class HelperStringer
{
    public static List<string[]> SetPartlyStrings(int count, List<string> listTarget)
    {

        List<string[]> allPartlyDialogues = new List<string[]>();
        for (int i = 0; i < count; i++)
        {
            string pDialogue = listTarget[i];
            string[] setPartly = pDialogue.Split('/');
            allPartlyDialogues.Add(setPartly);
        }
        return allPartlyDialogues;
    }

    public static string[] ListArrayToArray(List<string[]> listTargets, int listTargetsNumb, int targetNumb)
    {
        string[] targetArray = new string[targetNumb];
        if (listTargets.Count > 0)
        {
            string[] target = listTargets[listTargetsNumb];

            for (int i = 0; i < targetNumb; i++)
            {
                targetArray[i] = target[i];
            }
        }
        return targetArray;
    }

    
    public static List<string[]> ToListArray(string[] splitedValues = null)
    {
        List<string[]> targetList = new List<string[]>();
        for (int i = 0; i < splitedValues.Length; i++)
        {

        }

        return targetList;
    }
    public static string RemovingLastCharacter(string targetString, string flage)
    {
        int lastChar = targetString.LastIndexOf(flage);
        string newString = targetString.Remove(lastChar);
        return newString;
    }
    public static string AddingLastCharacter(string targetString,string lastChar)
    {
        string newString =  targetString + lastChar;
        return newString;
    }

    public static float MakeRandomNumber(float startFloat, float endFloat)
    {
        float randomFloat = Random.Range(startFloat, endFloat);

        return randomFloat;
    }
    public static int MakeRandomNumber(int startInt, int endInt)
    {
        int randomInt = Random.Range(startInt, endInt);

        return randomInt;
    }



}//EndClasss/SadeQ
