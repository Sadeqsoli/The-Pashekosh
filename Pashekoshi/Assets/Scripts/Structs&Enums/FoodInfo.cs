using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public struct FoodInfo
{
    [FormerlySerializedAs("cakeName")] 
    public FoodType foodType;
    [FormerlySerializedAs("cakePrefab")] 
    public GameObject foodPrefab;
    [FormerlySerializedAs("cakeSprites")] 
    public List<Sprite> foodSprites;
}