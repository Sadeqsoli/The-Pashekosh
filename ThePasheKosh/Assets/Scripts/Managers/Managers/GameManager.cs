using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PieceNumber { One, Two, Four}
public class GameManager : Singleton<GameManager>
{
    public LevelParameters[] levels;

    [Space]
    [Space]

    public CakeStruct[] cakes;

    int _currentLevel = 0;

    void Start()
    {
        AddEvents();
        AddListeners();

        CakeManager.Instance.PutTheCakes(cakes[0], PieceNumber.Four);
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

            //Whenever the player is game over this event will be invoked
            EventManager.AddEventWithNoParamter("GameOver");
            // Whenever an insect is killed, this event will be invoked with the insect game object as a parameter
            EventManager.AddGameObjectEvent("InsectKilled");

            // Whenever a piece of cake is completely destroyed, this event will be invoked
            EventManager.AddGameObjectEvent("CakePieceDestroyed");
        }
        else
        {
            Debug.LogError("The EventManager hasn't been initilized yet.");
        }
    }

    void AddListeners()
    {
        EventManager.StartListening("InsectKilled", ProcessKillings);
        EventManager.StartListening("GameOver", GameOver);
    }

    void GoToNextLevel()
    {
        ResultsController.Instance.ResetLevelCounters();

        InsectManager.Instance.StopAllSpawn(false);
        _currentLevel++;
        Timers.Instance.StartTimer(1, LoadLevel);
    }

    void LoadLevel()
    {
        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);
    }


    void ProcessKillings(GameObject insect)
    {
        Insect insectComponent = insect.GetComponent<Insect>();
        ResultsController.Instance.AddToScore(insectComponent.addedPoints);
        if (insectComponent.isBadInsect) ResultsController.Instance.TrueKill();
        else ResultsController.Instance.FalseKill();

        if (ResultsController.Instance.LevelTrueKillCounter >= levels[_currentLevel].levelParameters.passLevelKillNum)
        {
            GoToNextLevel();
        }
    }


    void GameOver()
    {
        PlayerPrefs.SetFloat("Last Score", ResultsController.Instance.Score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
