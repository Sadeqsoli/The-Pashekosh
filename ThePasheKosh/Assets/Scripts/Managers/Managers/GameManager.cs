using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelParametersStruct
{
    public string[] goodInsectsNames;
    public string[] badInsectsNames;
    public float timeBetweenSpawns;
    public float badInsectsPercentage;
    public float speedOfInsects;
    public float randomDirectionPercentage;
}

public class GameManager : Singleton<GameManager>
{
    public LevelParameters[] levelParameters;

    int _currentLevel = 0;

    public enum GameState
    {
        START,
        RUNNING,
        FINISHED
    }
    public GameState CurrentState { get; private set; } = GameState.START;
    
    void Start()
    {
        if (EventManager.IsInitialized)
        {
            // Addig a event with a GameObject parameter. 
            // Every time the player touch (or click) a collider this event will be invoked.
            EventManager.AddGameObjectEvent("TouchedCollider");
            // Every time the player touch the screen and not touch a collider this event will be invoked.
            EventManager.AddEventWithNoParamter("TouchedScreen");
        }

        ProcessGameStates();
    }

    
    /// <summary>
    /// Process UI for each game state. 
    /// </summary>
    public void ProcessGameStates()
    {
        switch (CurrentState)
        {
            case GameState.START:
                InsectManager.Instance.StartInsectSpawning(levelParameters[_currentLevel].levelParameters);
                break;
            case GameState.RUNNING:
                break;
            case GameState.FINISHED:

                break;
        }
    }

}
