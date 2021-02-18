using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DB 
{
    
    public static string Key(string targetID)
    {
        return "KeyRepositoryFor" + targetID;
    }

}
