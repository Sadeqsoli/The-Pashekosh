using UnityEngine;

public static class Calculator
{

    public static float CalculatePro(string newSource , string newTarget)
    {
        return CalculateSimilarity(newSource, newTarget) * 100;
    }

    static int ComputeLevenshteinDistance(string source, string target)
    {
        if ((source == null) || (target == null)) return 0;
        if ((source.Length == 0) || (target.Length == 0)) return 0;
        if (source == target) return source.Length;

        int sourceWordCount = source.Length;
        int targetWordCount = target.Length;

        // Step 1
        if (sourceWordCount == 0)
            return targetWordCount;

        if (targetWordCount == 0)
            return sourceWordCount;

        int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

        // Step 2
        for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
        for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

        for (int i = 1; i <= sourceWordCount; i++)
        {
            for (int j = 1; j <= targetWordCount; j++)
            {
                // Step 3
                int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                // Step 4
                distance[i, j] = Mathf.Min(Mathf.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
            }
        }

        return distance[sourceWordCount, targetWordCount];
    }

    /// <summary>
    /// Calculate percentage similarity of two strings
    /// <param name="source">Source String to Compare with</param>
    /// <param name="target">Targeted String to Compare</param>
    /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
    /// </summary>
    static float CalculateSimilarity(string source, string target)
    {
        if ((source == null) || (target == null)) return 0.0f;
        if ((source.Length == 0) || (target.Length == 0)) return 0.0f;
        if (source.ToLower() == target.ToLower()) return 1.0f;

        int stepsToSame = ComputeLevenshteinDistance(source, target);
        return (1.0f - ((float)stepsToSame / (float)Mathf.Max(source.Length, target.Length)));
    }


}//EndClasss/SadeQ
