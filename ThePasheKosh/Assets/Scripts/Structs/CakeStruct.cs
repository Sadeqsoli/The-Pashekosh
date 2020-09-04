using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CakeStruct
{
    int piecesNumber;
    Sprite[] cakePieces;
}

[System.Serializable]
class CakeWithNameDict : Dictionary<string, CakeStruct> { }