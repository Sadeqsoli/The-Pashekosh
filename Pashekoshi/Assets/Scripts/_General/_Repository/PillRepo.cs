using UnityEngine;

public static class PillRepo
{
    #region Properties
    public static string PillRepoName { get { return pillRepo; } }
    #endregion

    #region Fields
    const string pillRepo = "kelidRepo";
    #endregion

    #region Public Methods
    public static void PushPill(int newPills)
    {
        if (newPills > 0)
        {
            int allpills = GetPill();
            allpills += newPills;
            
            SaveRepo(pillRepo, allpills);
        }
    }
    public static bool PopPill(int count)
    {
        if (count > 0)
        {
            if (HasPill(count))
            {
                int allpills = GetPill();
                allpills -= count;
                SaveRepo(pillRepo, allpills);
                return true;
            }
        }
        return false;
    }

    public static int GetPill()
    {
        return Retrive(pillRepo);
    }


    #endregion

    #region Private Methods





    static bool HasPill(int Count)
    {
        int allPills = GetPill();
        if (allPills >= Count)
        {
            return true;
        }
        return false;
    }



    static int Retrive(string repoKey)
    {
        return PlayerPrefs.GetInt(repoKey);
    }
    static void SaveRepo(string repoKey, int pills)
    {
        PlayerPrefs.SetInt(repoKey, pills);
    }

    #endregion
}//EndClasssss/SadeQ
