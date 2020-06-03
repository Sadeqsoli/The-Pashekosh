using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum NPC_ObjectEnums
{
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
    TheBlackPirates1,
    TheBlackPirates2,
    TheBlackPirates3,
    TheBlackPirates4,
    TheBlackPirates5,
}

[System.Serializable]
public struct NPC_ObjectStruct
{
    [Header("--------------------------NPC_Objects Info--------------------------")]
    public NPC_ObjectEnums key;
    public GameObject npc_Object;
}

public class NPC_Objects_Repository : MonoBehaviour
{
    #region Properties
    public NPC_ObjectStruct[] npc_Objects;
    #endregion

    #region Fields
    #endregion

    #region Public Methods
    public GameObject EnemyShipSpawner(int index)
    {
        float instX = Random.Range(-8f, 8f);
        GameObject NPC_Object = Instantiate(npc_Objects[index].npc_Object, new Vector3(instX, 7, 0), Quaternion.identity); ;
        return NPC_Object;
    }
    #endregion





    #region Private Methods
    void Start()
    {

    }//Starttttt




    


    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss/SadeQ
