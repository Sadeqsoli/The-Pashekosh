using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
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
    }

    
    /// <summary>
    /// Process UI for each game state. 
    /// </summary>
    public void ProcessGameStates()
    {
        switch (CurrentState)
        {
            case GameState.START:

                break;
            case GameState.RUNNING:

                break;
            case GameState.FINISHED:

                break;
        }
    }
}
