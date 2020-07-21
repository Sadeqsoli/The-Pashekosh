using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreRepository : MonoBehaviour
{
    #region Properties
    public string RepositeName { get { return repositeName; } }
    #endregion

    #region Private Variables
    const string lastScoreRepository = "lastScoreRepository";
    const string highScoreRepository = "highScoreRepository";
    const string repositeName = "scoreRepo";
    int scores;
    #endregion

    #region Fields

    public void PushScores(int count)
    {
        if (count > 0)
        {
            scores = scores + count;
            Save(repositeName, scores);
        }
    }
    public void Push(int s)
    {
        Save(lastScoreRepository, s);
        int h = GetHighScore();
        if(s > h)
        {
            Save(highScoreRepository, s);
        }
    }

    public int Get()
    {
        return Retrive(repositeName);
    }
    public int GetLastScore()
    {
        return Retrive(lastScoreRepository);
    }
    public int GetHighScore()
    {
        return Retrive(highScoreRepository);
    }
    #endregion




    #region Private Methods
    void Start()
    {
        scores = Retrive(repositeName);

    }//Starttttt




    private bool Has(int Count)
    {
        if (scores >= Count)
        {
            return true;
        }
        return false;
    }
    private int Retrive(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
    private void Save(string key, int val)
    {
        PlayerPrefs.SetInt(key, val);
    }





    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
  