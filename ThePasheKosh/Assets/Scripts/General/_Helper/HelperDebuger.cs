using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HelperDebuger
{

    public static void ColoredLog(string text, Colors color) 
    {
        Debug.Log("<color="+ColorsDictionary[color]+">" +text+ "</color>");
    }

    private static readonly Dictionary<Colors, string> ColorsDictionary = new Dictionary<Colors, string>()
        {

            {Colors.orange,"#FFA500"},
            {Colors.olive,"#808000"},
            {Colors.purple,"#800080"},
            {Colors.darkered,"#8B0000"},
            {Colors.darkgreen,"#006400"},
            {Colors.darkorange,"#FF8C00"},
            {Colors.gold,"#FFD700"},
        };
}//EndClassss/SadeQ

public enum Colors
{
    orange, olive, purple, darkered, darkgreen, darkorange, gold
}
