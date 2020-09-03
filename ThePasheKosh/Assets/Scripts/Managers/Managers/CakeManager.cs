using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
class CakeWithNameDict : Dictionary<string, CakeStruct> { }
public class CakeManager : Singleton<CakeManager>
{
    CakeWithNameDict[] cakes;

    void initializeCakeManager()
    {

    }

}
