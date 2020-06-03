using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData
{
    private static Vector3 _worldBoundries;
    public static Vector3 CalculateBoundires(Camera mainCamera)
    {
        var screenBoundries = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        _worldBoundries = mainCamera.ScreenToWorldPoint(screenBoundries);
        return _worldBoundries;
    }

}
