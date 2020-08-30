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
    public LevelParameters[] levels;

    public GameObject StartCanvas;
    public GameObject RunningCanvas;
    public GameObject FinishCanvas;


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
        AddEvents();
        AddListeners();
        ProcessGameStates();
    }

    void AddEvents()
    {
        if (EventManager.IsInitialized)
        {
            // Addig a event with a GameObject parameter. 
            // Every time the player touch (or click) a collider this event will be invoked.
            EventManager.AddGameObjectEvent("TouchCollider");
            // Every time the player touch the screen and not touch a collider this event will be invoked.
            EventManager.AddEventWithNoParamter("TouchScreen");
            // Whenever an insect is killed, this event will be invoked with the insect game object as a parameter
            EventManager.AddGameObjectEvent("InsectKilled");
        }
        else
        {
            Debug.LogError("The EventManager hasn't been initilized yet.");
        }
    }

    void AddListeners()
    {
        EventManager.StartListening("InsectKilled", ProcessKillings);
    }

    
    /// <summary>
    /// Process UI for each game state. 
    /// </summary>
    public void ProcessGameStates()
    {
        switch (CurrentState)
        {
            case GameState.START:
                ShowRelatedCanvas(true, false, false);
                
                break;
            case GameState.RUNNING:
                ShowRelatedCanvas(false, true, false);
                InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);

                break;
            case GameState.FINISHED:
                ShowRelatedCanvas(false, false, true);
                break;
        }
    }

    void GoToNextLevel()
    {
        InsectManager.Instance.RemoveInsects();
        _currentLevel++;
        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);
    }

    void FinishTheGame()
    {
        InsectManager.Instance.RemoveInsects();
        CurrentState = GameState.FINISHED;
        ProcessGameStates();
    }

    void ProcessKillings(GameObject insect)
    {
        Insect insectComponent = insect.GetComponent<Insect>();
        ResultsController.Instance.AddToScore(insectComponent.addedPoints);
        if (insectComponent.isBadInsect) ResultsController.Instance.AddToFalseSelections();
        else ResultsController.Instance.AddToTrueSelections();
    }

    public void ShowRelatedCanvas(bool startState, bool runningState, bool finishedState)
    {
        StartCanvas.SetActive(startState);
        RunningCanvas.SetActive(runningState);
        FinishCanvas.SetActive(finishedState);
    }

    public void StartTheGame()
    {
        CurrentState = GameState.RUNNING;
        ProcessGameStates();
    }

    

}
