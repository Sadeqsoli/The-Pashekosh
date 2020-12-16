using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


[System.Serializable]
public struct FoodInfo
{
    [FormerlySerializedAs("cakeName")] 
    public string foodName;
    [FormerlySerializedAs("cakePrefab")] 
    public GameObject foodPrefab;
    [FormerlySerializedAs("cakeSprites")] 
    public List<Sprite> foodSprites;
}


public class GameManager : Singleton<GameManager>
{
    #region Public Variables

    public LevelParameters[] levels;

    [FormerlySerializedAs("cakes")]
    [Space]
    [Space]
    public List<FoodInfo> foods;

    [Space]
    [Space]

    public UIManager gameUIManager;

    [Space] 
    public SpriteRenderer background;

    #endregion

    #region Private Variables
    int foodIndex = 0;
    int _currentLevel = 0;

    float _timer;

    #endregion

    public void UpdateHealth(float health, float maxHealth)
    {
        gameUIManager.UpdateHealth(health);
        //HealthFill.ShowHealth(health, maxHealth);
    }

    void Start()
    {
        //To Fit Camera Side to Side With The Screen
        CameraScaler.CameraFit(background);
        if (!PlayerPrefs2.GetBool("MoreThanOneTime"))
        {
            PlayerPrefs2.SetBool("MoreThanOneTime", true);
            //PlayerPrefs.SetFloat("HighScore", 0);
        }

        AddEvents();
        
        AddListeners();

        LoadLevel();

        _timer = 0;
        Timers.Instance.StartRepeatedAction(1f, AddToTimer);

        gameUIManager.Initialize(0, 100);
        
        FoodManager.Instance.MakeTheFoodReady(foods[foodIndex]);
    }

    #region Events Handling
    void AddEvents()
    {
        if (EventManager.IsInitialized)
        {
            // Addig a event with a GameObject parameter. 
            // Every time the player touch (or click) a collider this event will be invoked.
            EventManager.AddGameObjectEvent(Events.TouchCollider);
            // Every time the player touch the screen and not touch a collider this event will be invoked.
            EventManager.AddEventWithNoParamter(Events.TouchScreen);

            //Whenever the player is game over this event will be invoked
            EventManager.AddEventWithNoParamter(Events.GameOver);
            // Whenever an insect is killed, this event will be invoked with the insect game object as a parameter
            EventManager.AddGameObjectEvent(Events.InsectKilled);

            // Whenever a piece of food is completely destroyed, this event will be invoked
            EventManager.AddGameObjectEvent(Events.FoodDestruction);
        }
        else
        {
            Debug.LogError("The EventManager hasn't been initilized yet.");
        }
    }

    void AddListeners()
    {
        EventManager.StartListening(Events.InsectKilled, ProcessKillings);
        EventManager.StartListening(Events.GameOver, GameOver);
    }

    #endregion


    #region Level Handling

    void GoToNextLevel()
    {
        InsectManager.Instance.StopAllSpawn(false);

        if(_currentLevel < levels.Length - 1)
            _currentLevel++;

        Timers.Instance.StartTimer(1, LoadLevel);
    }

    void LoadLevel()
    {
        Timers.Instance.StartTimer(levels[_currentLevel].levelParameters.passLevelTime, GoToNextLevel);
        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);
    }

    #endregion

    #region Kill and GameOver Handling
    void ProcessKillings(GameObject insect)
    {
        Insect insectComponent = insect.GetComponent<Insect>();
        if (insectComponent.IsBadInsect)
        {
            BadInsect badInsectComponent = insect.GetComponent<BadInsect>();
            ResultsController.Instance.AddToScore(badInsectComponent.addedPoints);
            ResultsController.Instance.TrueKill();
        }
        else GameOver();
        gameUIManager.UpdateScore(ResultsController.Instance.Score);

    }


    void GameOver()
    {
        float score = ResultsController.Instance.Score;
        ScoreRepo.PushScore(score);
        TimeRepo.PushTime(_timer);
        LevelRepo.PushLevel(_currentLevel + 1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion


    #region Game Timer Handling

    void AddToTimer(float seconds)
    {
        _timer += seconds;
        if (gameUIManager != null)

        gameUIManager.UpdateScore(ResultsController.Instance.Score);
    }

    #endregion

    

}
