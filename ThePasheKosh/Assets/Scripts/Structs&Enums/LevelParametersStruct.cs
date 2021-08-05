using UnityEngine;

[System.Serializable]
public struct MinMaxRandom
{
    public float min;
    public float max;
}

[System.Serializable]
public struct InsectParameters
{
    public InsectType[] insectsName;
    [Space]
    public MinMaxRandom timeBetweenSpawn;
    public MinMaxRandom insectSpeed;
    public MinMaxRandom insectRotSpeed;
    [Space]
    [Range(0, 0.45f)]
    public float randomnessOfDirection;
}

[System.Serializable]
public struct LevelParametersStruct
{
    public InsectParameters badInsectParameters;

    [Space]
    public InsectParameters goodInsectPrarmeters;

    [Header("General")]
    public int passLevelTime;
}

public enum InsectType { Ant, Bee, Bug, Butterfly, Dragonfly, BlueHousefly, LadyBug, Masquote, RedHousefly, Spider }