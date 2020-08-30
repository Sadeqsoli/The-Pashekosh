using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelParametersStruct
{
    public string[] goodInsectsNames;
    public string[] badInsectsNames;
    public float timeBetweenSpawns;
    [Range(0,1)]
    public float badInsectsPercentage;
    public float speedOfInsects;
    [Range(0, 1)]
    public float randomDirectionPercentage;
}

public class GameManager : Singleton<GameManager>
{
    public LevelParameters[] levels;

    [Space][Space]

    int _currentLevel = 0;

    void Start()
    {
        AddEvents();
        AddListeners();

        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);
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

    void GoToNextLevel()
    {
        InsectManager.Instance.RemoveInsects();
        _currentLevel++;
        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);
    }

    void FinishTheGame()
    {
    }

    void ProcessKillings(GameObject insect)
    {
        Insect insectComponent = insect.GetComponent<Insect>();
        ResultsController.Instance.AddToScore(insectComponent.addedPoints);
        if (insectComponent.isBadInsect) ResultsController.Instance.AddToFalseSelections();
        else ResultsController.Instance.AddToTrueSelections();
    }
}
