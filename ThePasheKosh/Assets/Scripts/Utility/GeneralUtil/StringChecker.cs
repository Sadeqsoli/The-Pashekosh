using System;
using System.Text.RegularExpressions;

public static class StringChecker 
{

    public static string RemoveMarks(string newInput)
    {
        return Replacer(newInput);
    }
    static string Replacer(string input)
    {
        string a = input.Replace("\"", "");
        string b = a.Replace(",", "");
        string c = b.Replace("-", "");
        string d = c.Replace("'", "");
        string e = d.Replace("?", "");
        string f = e.Replace("!", "");
        string g = f.Replace(".", "");
        string h = g.Replace("/", "");
        string i = h.ToLower();

        return i;
    }

    public static bool IsMatchWith(string input , string pattern)
    {
        return Regex.Match(input, pattern).Success;
    }

    public static bool IsMatchPattern(string input , string pattern)
    {
        return Regex.IsMatch(input, pattern);
    }


    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source.IndexOf(toCheck, comp) >= 0;
    }


    public static string Replace(this string source, string oldString,
                            string newString, StringComparison comparison)
    {
        int index = source.IndexOf(oldString, comparison);

        while (index > -1)
        {
            source = source.Remove(index, oldString.Length);
            source = source.Insert(index, newString);

            index = source.IndexOf(oldString, index + newString.Length, comparison);
        }

        return source;
    }


    //didn't used before
    public static string GetBetween(string strSource, string strStart, string strEnd)
    {
        const int kNotFound = -1;

        var startIdx = strSource.IndexOf(strStart);
        if (startIdx != kNotFound)
        {
            startIdx += strStart.Length;
            var endIdx = strSource.IndexOf(strEnd, startIdx);
            if (endIdx > startIdx)
            {
                return strSource.Substring(startIdx, endIdx - startIdx);
            }
        }
        return String.Empty;
    }

    //didn't used before
    public static string ReplaceTextBetween(string strSource, string strStart, string strEnd, string strReplace)
    {
        int Start, End, strSourceEnd;
        if (strSource.Contains(strStart) && strSource.Contains(strEnd))
        {
            Start = strSource.IndexOf(strStart, 0) + strStart.Length;
            End = strSource.IndexOf(strEnd, Start);
            strSourceEnd = strSource.Length - 1;

            string strToReplace = strSource.Substring(Start, End - Start);
            string newString = string.Concat(strSource.Substring(0, Start), strReplace, strSource.Substring(Start + strToReplace.Length, strSourceEnd - Start));
            return newString;
        }
        else
        {
            return string.Empty;
        }
    }

   
   

}//EndClassss/SadeQ
