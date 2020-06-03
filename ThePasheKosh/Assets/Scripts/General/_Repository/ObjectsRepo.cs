using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsRepo : MonoBehaviour
{
    #region Properties
    #endregion

    #region Fields
    private const string destroyedRepo = "destroyedRepo";
    private const string enemyshipRepo = "enemyshipRepo";
    private const string childshipRepo = "childshipRepo";
    private const string candyRepo = "candyRepo";
    private const string magicRepo = "magicRepo";
    private const string junkRepo = "junkRepo";
    private int destroyed;
    private int enemyShip;
    private int childShip;
    private int candy;
    private int magicCandy;
    private int junkCandy;
    #endregion

    #region Public Methods
   

    public void PushDestroyed(int count)
    {
        if (count > 0)
        {
            destroyed = destroyed + count;
            Save(destroyedRepo, destroyed);
        }
    }
    public void PushEnemy(int count)
    {
        if (count > 0)
        {
            enemyShip = enemyShip + count;
            Save(enemyshipRepo, enemyShip);
        }
    }
    public void PushChild(int count)
    {
        if (count > 0)
        {
            childShip = childShip + count;
            Save(childshipRepo, childShip);
        }
    }
    public void PushCandy(int count)
    {
        if (count > 0)
        {
            candy = candy + count;
            Save(candyRepo, candy);
        }
    }
    public void PushMagic(int count)
    {
        if (count > 0)
        {
            magicCandy = magicCandy + count;
            Save(magicRepo, magicCandy);
        }
    }
    public void PushJunk(int count)
    {
        if (count > 0)
        {
            junkCandy = junkCandy + count;
            Save(junkRepo, junkCandy);
        }
    }
    

    public int GetDestroyed()
    {
        return Retrive(destroyedRepo);
    }
    public int GetEnemy()
    {
        return Retrive(enemyshipRepo);
    }
    public int GetChild()
    {
        return Retrive(childshipRepo);
    }
    public int GetCandy()
    {
        return Retrive(candyRepo);
    }
    public int GetMagic()
    {
        return Retrive(magicRepo);
    }
    public int GetJunk()
    {
        return Retrive(junkRepo);
    }
    #endregion




    #region Private Methods
    void Start()
    {
        destroyed = Retrive(destroyedRepo);
        enemyShip = Retrive(enemyshipRepo);
        childShip = Retrive(childshipRepo);
        candy = Retrive(candyRepo);
        magicCandy = Retrive(magicRepo);
        junkCandy = Retrive(junkRepo);
    }//Starttttt





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
