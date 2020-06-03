using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData 
{
    public static PlayerIndentity playerIdentity;   
}
public struct PlayerIndentity
{
    public string PhoneNumber;
    public string NickName;
    public string FamilyName;
    public string DisplayName;
    public bool IsFemale;
    public int Age;
    public string AuthToken;
}

public struct PlayerGameState
{
    public int Gold;
    public int Gem;
    public int MainGameCurrentLevel;
}









