using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRepository : MonoBehaviour
{
    #region Properties
    public string RpositoryName { get { return repositoryName;  } }
    #endregion

    #region Fields
    private const string repositoryName = "coinRepository";
    private int coins;
    #endregion

    #region Public Methods
    public bool Pop(int count)
    {
        if (Has(count))
        {
            coins = coins - count;
            SaveRepo();
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
            coins = coins + count;
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
        coins = Retrive();
        
    }//Starttttt




    private bool Has(int Count)
    {
        if(coins >= Count)
        {
            return true;
        }
        return false;
    }

    private int Retrive()
    {
        return PlayerPrefs.GetInt(repositoryName);
    }

    private void SaveRepo()
    {
        PlayerPrefs.SetInt(repositoryName, coins);
    }

   


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
