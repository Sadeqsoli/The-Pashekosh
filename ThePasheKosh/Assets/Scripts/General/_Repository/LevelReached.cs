using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelReached : MonoBehaviour
{
    #region Properties
    public string RepoLevel { get { return LEVELREACHED; } }
    #endregion

    #region Fields
    private const string LEVELREACHED = "levelreached";
    private int ReachedLevel;
    #endregion

    #region Public Methods
    public void Push(int count)
    {
        if (count > 0)
        {
            ReachedLevel = count;
            SaveRepo();
        }
    }

    public int Get()
    {
        return Retrive();
    }
   
    #endregion


    #region Private Methods
    void Start()
    {
        ReachedLevel = Retrive();
    }//Starttttt

   

    private int Retrive()
    {
        return PlayerPrefs.GetInt(LEVELREACHED);
    }
    private void SaveRepo()
    {
        PlayerPrefs.SetInt(LEVELREACHED, ReachedLevel);
    }




    void Update()
    {

    }//Updateeeee
  
    #endregion
}//EndClasssss/SadeQ
