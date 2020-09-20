using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum PieceNumber { One, Two, Four}
public class GameManager : Singleton<GameManager>
{
    #region Public Variables

    public LevelParameters[] levels;

    [Space]
    [Space]

    public CakeStruct[] cakes;

    [Space]
    [Space]

    public UIManager gameUIManager;

    #endregion

    #region Private Variables

    int _cakeIndex = 0;
    int _currentLevel = 0;

    float _timer;

    #endregion

    public void UpdateHealth(float health)
    {
        gameUIManager.UpdateHealth(health);
    }

    void Start()
    {
        if (!PlayerPrefs2.GetBool("MoreThanOneTime"))
        {
            PlayerPrefs2.SetBool("MoreThanOneTime", true);
            PlayerPrefs.SetFloat("HighScore", 0);
        }

        AddEvents();
        AddListeners();

        CakeManager.Instance.PutTheCakes(cakes[_cakeIndex], PieceNumber.Four);
        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);

        _timer = 0;
        Timers.Instance.StartRepeatedAction(1f, AddToTimer);

        gameUIManager.Initialize(0, 0, cakes[_cakeIndex].maxHealth * 4 / 3, 0, 1);
    }

    #region Events Handling
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

    #endregion


    #region Level Handling

    void GoToNextLevel()
    {
        ResultsController.Instance.ResetLevelCounters();

        InsectManager.Instance.StopAllSpawn(false);
        _currentLevel++;
        Timers.Instance.StartTimer(1, LoadLevel);

        gameUIManager.UpdateLevel(_currentLevel + 1);
    }

    void LoadLevel()
    {
        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);
    }

    #endregion

    #region Kill and GameOver Handling
    void ProcessKillings(GameObject insect)
    {
        Insect insectComponent = insect.GetComponent<Insect>();
        ResultsController.Instance.AddToScore(insectComponent.addedPoints);
        if (insectComponent.isBadInsect) ResultsController.Instance.TrueKill();
        else GameOver();

        gameUIManager.UpdateKillNumber(ResultsController.Instance.LevelTrueKillCounter);
        gameUIManager.UpdateScore(ResultsController.Instance.Score);

        if (ResultsController.Instance.LevelTrueKillCounter >= levels[_currentLevel].levelParameters.passLevelKillNum)
        {
            GoToNextLevel();
        }
    }


    void GameOver()
    {
        float score = ResultsController.Instance.Score;
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.SetFloat("Time", _timer);
        PlayerPrefs.SetInt("Level", _currentLevel + 1);
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        PlayerPrefs.SetFloat("Last Score", ResultsController.Instance.Score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion


    #region Game Timer Handling

    void AddToTimer(float seconds)
    {
        _timer += seconds;
        if (gameUIManager != null)
            gameUIManager.UpdateTimer(_timer);

        ResultsController.Instance.AddToScore(seconds);
        gameUIManager.UpdateScore(ResultsController.Instance.Score);
    }

    #endregion

}
