using UnityEngine;

[System.Serializable]
public struct LevelParametersStruct
{
    public string[] goodInsectsNames;
    public string[] badInsectsNames;
    public int passLevelKillNum;
    public float timeBetweenSpawns;
    [Range(0, 1)]
    public float badInsectsPercentage;
    public float speedOfInsects;
    [Range(0, 1)]
    public float randomDirectionPercentage;
}
