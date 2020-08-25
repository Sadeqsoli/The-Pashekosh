using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjEnums
{
    DragonOfTheSeas1,
    DragonOfTheSeas2,
    DragonOfTheSeas3,
    DragonOfTheSeas4,
    DragonOfTheSeas5,
    SwordsOfTheTruth1,
    SwordsOfTheTruth2,
    SwordsOfTheTruth3,
    SwordsOfTheTruth4,
    SwordsOfTheTruth5,
    QueenOfTheSeas1,
    QueenOfTheSeas2,
    QueenOfTheSeas3,
    QueenOfTheSeas4,
    QueenOfTheSeas5,
    TheBlackSwan1,
    TheBlackSwan2,
    TheBlackSwan3,
    TheBlackSwan4,
    TheBlackSwan5,
    TheBlackDragon1,
    TheBlackDragon2,
    TheBlackDragon3,
    TheBlackDragon4,
    TheBlackDragon5,
    TheKingOfTheSeas1,
    TheKingOfTheSeas2,
    TheKingOfTheSeas3,
    TheKingOfTheSeas4,
    TheKingOfTheSeas5,
    TheYoungLion1,
    TheYoungLion2,
    TheYoungLion3,
    TheYoungLion4,
    TheYoungLion5,
    TheGoldenGriffin1,
    TheGoldenGriffin2,
    TheGoldenGriffin3,
    TheGoldenGriffin4,
    TheGoldenGriffin5,
    TheGiftOfDeath1,
    TheGiftOfDeath2,
    TheGiftOfDeath3,
    TheGiftOfDeath4,
    TheGiftOfDeath5,
    TheRageOfGods1,
    TheRageOfGods2,
    TheRageOfGods3,
    TheRageOfGods4,
    TheRageOfGods5,
    MasterOfTheSeas1,
    MasterOfTheSeas2,
    MasterOfTheSeas3,
    MasterOfTheSeas4,
    MasterOfTheSeas5,
    TheRedPirates1,
    TheRedPirates2,
    TheRedPirates3,
    TheRedPirates4,
    TheRedPirates5,
}
public enum SubObjType
{
    SubObjType1,
    SubObjType2,
    SubObjType3,
    SubObjType4,
    SubObjType5,
    SubObjType6
}
[System.Serializable]
public struct ObjStruct
{
    [Header("--------------------------Object Info--------------------------")]
    public ObjEnums key;
    public GameObject Object;
    [Range(1, 20)]
    public int speed;
    [Range(1, 1500)]
    public int health;
    [Range(1,20)]
    public int guns;
    [Range(1, 100)]
    public int bulletPower;
    [Range(0.0f, 5f)]
    public float fireRate;
    public string model;
    public SubObjType bulletType;
    public int price;
    public bool isLocked;
    public Sprite sprite;
    public Sprite sprite1;
    public Sprite canonBall;
    
}

public class ObjectRepository : MonoBehaviour
{
    #region Properties
    public int ObjectsCount { get { return _object.Length; } }
    #endregion

    #region Fields
    public ObjStruct[] _object;
    const string currentObjectRepo = "currentObjectRepo";
    const string ObjectsRepo = "objectsRepo";
    int currentObj;
    #endregion

    #region Public Methods

    public ObjStruct GetShipsByIndex(int i)
    {
        _object[i].isLocked = !IsObjectActive(i);

        return _object[i];
    }

    public ObjStruct GetCurrentShip()
    {
        int Index = GetCurrentShipNumb();
        _object[Index].isLocked = IsObjectActive(Index);
        return _object[Index];
    }
  
    public int GetCurrentShipNumb()
    {
        return RetriveCurrentObject();
    }
    public void PushCurrentShip(int count)
    {
        if (count >= 0)
        {
            currentObj = count;
            SaveCurrentObject();
        }
    }

    public void ActiveNewShip(int i)
    {
        string s = RetriveObjects();
        s += i.ToString();
        SaveObjects(s);
    }

    #endregion





    #region Private Methods
    void Start()
    {
        currentObj = RetriveCurrentObject();
    }//Starttttt

    private void SaveObjects(string s)
    {
        PlayerPrefs.SetString(ObjectsRepo, s);
    }
    private string RetriveObjects()
    {
        return PlayerPrefs.GetString(ObjectsRepo);
    }


    private bool IsObjectActive(int i)
    {
        string s = PlayerPrefs.GetString(ObjectsRepo);
        if (s.Contains(i.ToString()))
        {
            
            return true;

        }
        else
        {
            
            return false;
        }
    }



    private int RetriveCurrentObject()
    {
        return PlayerPrefs.GetInt(currentObjectRepo);
    }

    private void SaveCurrentObject()
    {
        PlayerPrefs.SetInt(currentObjectRepo, currentObj);
    }


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
