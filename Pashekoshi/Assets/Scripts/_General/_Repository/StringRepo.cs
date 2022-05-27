using System;
using UnityEngine;

public class StringRepo : MonoBehaviour
{
    #region Properties
    public string RepoUser { get { return repoWord; } }
    public string RepoSentence { get { return repoSentence; } }
    #endregion

    #region Fields
    const string repoWord = "wordRepo";
    const string repoSentence = "sentenceRepo";

    string fieldSeprator = "/";
    string words;
    string sentences;

    #endregion

    #region Public Methods
    public void PopWord(string oldWord)
    {
        if (!HasWord(oldWord))
            return;

        DeleteWord(oldWord);
    }
    public void PopSentence(string oldSentence)
    {
        if (!HasSentence(oldSentence))
            return;

        DeleteSentence(oldSentence);
    }

    public void PushWord(string newWord)
    {
        if (HasWord(newWord))
            return;

        words += newWord + fieldSeprator;
        Save(repoWord, words);
    }
    public void PushSentence(string newSentenc)
    {
        if (HasSentence(newSentenc))
            return;
        sentences += newSentenc + fieldSeprator;
        Save(repoSentence, sentences);
    }



    public string GetWord()
    {
        int lastSlashW = Retrive(repoWord).LastIndexOf(fieldSeprator);
        string words = Retrive(repoWord).Remove(lastSlashW);
        return words;
    }
    public string GetSentence()
    {
        int lastSlashS = Retrive(repoSentence).LastIndexOf(fieldSeprator);
        string sentences = Retrive(repoSentence).Remove(lastSlashS);
        return sentences;
    }


    #endregion




    #region Private Methods
    void Start()
    {
        words = GetWord();
        sentences = GetSentence();

    }//Starttttt




    private string[] RetriveWordsFromRepoToArray()
    {
        string Allwords = Retrive(repoWord);
        return Allwords.Split('/');
    }
    private string[] RetriveSentencesFromRepoToArray()
    {
        string AllSentences = Retrive(repoSentence);
        return AllSentences.Split('/');
    }

    private bool HasWord(string NewWord)
    {
        string[] Allwords = RetriveWordsFromRepoToArray();
        for (int i = 0; i < Allwords.Length; i++)
        {
            if (Allwords[i] == NewWord)
            {
                return true;
            }
        }
        return false;
    }
    private bool HasSentence(string NewSentence)
    {
        string[] AllSentence = RetriveSentencesFromRepoToArray();
        for (int i = 0; i < AllSentence.Length; i++)
        {
            
            if (AllSentence[i] == NewSentence)
            {
                //string o = "$";
                //string n = "dollar";
                //if (AllSentence[i].Contains(o))
                //{
                //    AllSentence[i].Replace(o, n);
                //}
                return true;
            }
        }
        return false;
    }


    private void DeleteWord(string oldWord)
    {
        string[] Allwords = RetriveWordsFromRepoToArray();
        for (int i = 0; i < Allwords.Length; i++)
        {
            if (Allwords[i] == oldWord)
            {
                Allwords[i] = "";
                words = ConvertToString(Allwords);
                Save(repoWord, words);
            }
        }
    }
    private void DeleteSentence(string oldSentence)
    {
        string[] AllSentences = RetriveSentencesFromRepoToArray();
        for (int i = 0; i < AllSentences.Length; i++)
        {
            if (AllSentences[i] == oldSentence)
            {
                AllSentences[i] = "";
                sentences = ConvertToString(AllSentences);
                Save(repoSentence, sentences);
            }
        }
    }




    private string ConvertToString(string[] str)
    {
        string newS = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (!String.IsNullOrEmpty(str[i]))
            {
                newS += str[i] + fieldSeprator;
            }
        }
        return newS;
    }

    private string Retrive(string key)
    {
        return PlayerPrefs.GetString(key);
    }
    private void Save(string key, string val)
    {
        PlayerPrefs.SetString(key, val);
        PlayerPrefs.Save();
    }



    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
