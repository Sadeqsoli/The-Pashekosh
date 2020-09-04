using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct CakeStruct
{
    public string nameOfCake;
    public Sprite wholeCake;
    [Space][Space]
    public Sprite[] cake2Pieces;
    [Space]
    [Space]
    public Sprite[] cake4Pieces;
    [Space]
    [Space]
    public int maxHealth;
}