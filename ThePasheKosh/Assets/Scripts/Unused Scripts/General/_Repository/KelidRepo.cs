using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KelidRepo : MonoBehaviour
{
    #region Properties
    public string RepoName { get { return kelidrepo;  } }
    #endregion

    #region Fields
    private const string kelidrepo = "kelidRepo";
    private int kelid;
    #endregion

    #region Public Methods
    public bool Pop(int count)
    {
        if (Has(count))
        {
            if (count >= 0)
            {
                kelid = kelid - count;
                SaveRepo();
            }
            return true; 
        }
        else
        {
            return false;
        }
    }

    public int Get()
    {
        return Retrive();
    }
    public void Push(int count)
    {
        if(count > 0)
        {
            kelid = kelid + count;
            SaveRepo();
        }
    }
    public void Save()
    {
       SaveRepo();
    }

    #endregion

    #region Private Methods
    private void Start()
    {
        kelid = Retrive();

    }//Starttttt




    private bool Has(int Count)
    {
        if(kelid >= Count)
        {
            return true;
        }
        return false;
    }
    private int Retrive()
    {
        return PlayerPrefs.GetInt(kelidrepo);
    }
    private void SaveRepo()
    {
        PlayerPrefs.SetInt(kelidrepo, kelid);
    }

   


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
