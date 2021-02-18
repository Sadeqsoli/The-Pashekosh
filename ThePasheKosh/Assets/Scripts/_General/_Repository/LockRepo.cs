using UnityEngine;


public static class LockRepo
{
    #region Properties
    #endregion

    #region Fields
    const string repo_OPENED = "OpenedTarget";
    const string fieldSeprator = "/";
    #endregion

    #region Public Methods
    public static void OpenTarget(string target)
    {
        if (IsRepoHas(target))
            return;
        string value = Retrive(repo_OPENED);
        value += target + fieldSeprator;
        Save(repo_OPENED, value);
    }
    public static bool IsRepoHas(string NewInput)
    {
        string[] repoTarget = RetriveFromRepoToArray();
        for (int i = 0; i < repoTarget.Length; i++)
        {
            if (repoTarget[i] == NewInput)
            {
                return true;
            }
        }
        return false;
    }
    public static string GetOpenedTarget()
    {
        string repoTarget = "";
        if (PlayerPrefs.HasKey(repo_OPENED))
        {
            int lastSlashW = Retrive(repo_OPENED).LastIndexOf(fieldSeprator);
            repoTarget = Retrive(repo_OPENED).Remove(lastSlashW);
        }
        return repoTarget;
    }
    #endregion


    #region Private Methods


    static string[] RetriveFromRepoToArray()
    {
        string repoTarget = Retrive(repo_OPENED);
        return repoTarget.Split('/');
    }
    static void DeleteFromRepo(string oldInput)
    {
        string[] Allwords = RetriveFromRepoToArray();
        string value = Retrive(repo_OPENED);
        for (int i = 0; i < Allwords.Length; i++)
        {
            if (Allwords[i] == oldInput)
            {
                Allwords[i] = "";
                value = ConvertToString(Allwords);
                Save(repo_OPENED, value);
            }
        }
    }

    static string ConvertToString(string[] str)
    {
        string newS = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (!string.IsNullOrEmpty(str[i]))
            {
                newS += str[i] + fieldSeprator;
            }
        }
        return newS;
    }






    static string Retrive(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    static void Save(string key, string val)
    {
        PlayerPrefs.SetString(key, val);
    }
    #endregion
}//EndClasssss


