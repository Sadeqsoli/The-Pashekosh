using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;


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

    [Space] 
    public Button playButton;
    public Button pauseButton;

    [Space] 
    public Button settingButton;
    public GameObject settingPanel;

    [Space] 
    public Button powerUpsButton;
    public GameObject powerUpsPanel;
    

    #endregion

    #region Private Variables
    private int foodIndex = 0;
    private int _currentLevel = 0;

    private float _timer;

    #endregion
    
    #region Properties
    
    public bool IsTouchable { private set; get; }
    #endregion
    
    #region Unity Methods
    private void Start()
    {
        //To Fit Camera Side to Side With The Screen
        CameraScaler.CameraFit(background);
        if (!PlayerPrefs2.GetBool("MoreThanOneTime"))
        {
            PlayerPrefs2.SetBool("MoreThanOneTime", true);
            //PlayerPrefs.SetFloat("HighScore", 0);
        }
        
        // Hide in-game panels
        HideSettingPanel();
        HidePowerUpsPanel();
        
        // Add listener and events
        AddEvents();
        AddListeners();

        // Load the level
        LoadLevel();
        
        // Start the timer
        _timer = 0;
        Timers.Instance.StartRepeatedAction(1f, AddToTimer);

        gameUIManager.Initialize(0, 100);
        
        FoodManager.Instance.MakeTheFoodReady(foods[foodIndex]);

        IsTouchable = true;
    }
    
    #endregion 
    
    #region Public Functions
    public void UpdateHealth(float health, float maxHealth)
    {
        gameUIManager.UpdateHealth(health);
        //HealthFill.ShowHealth(health, maxHealth);
    }
    #endregion

    #region Events Handling
    private void AddEvents()
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
            EventManager.AddEventWithNoParamter(Events.FoodDestruction);
            
            // Whenever we want to mute or unmute the insects and background sounds
            EventManager.AddBoolEvent(Events.BackgroundSound);
            EventManager.AddBoolEvent(Events.InsectsSound);
        }
        else
        {
            Debug.LogError("The EventManager hasn't been initilized yet.");
        }
    }

    private void AddListeners()
    {
        // Add event manager listeners
        EventManager.StartListening(Events.InsectKilled, ProcessKillings);
        EventManager.StartListening(Events.GameOver, GameOver);

        // Add buttons listeners
        if (pauseButton != null && playButton != null)
        {
            playButton.onClick.AddListener(PlayGame);
            pauseButton.onClick.AddListener(PauseGame);
        }
        
        settingButton.onClick.AddListener(ShowSettingPanel);
        powerUpsButton.onClick.AddListener(ShowPowerUpsPanel);
    }

    #endregion


    #region Level Handling

    private void GoToNextLevel()
    {
        InsectManager.Instance.StopAllSpawn(false);

        if(_currentLevel < levels.Length - 1)
            _currentLevel++;

        Timers.Instance.StartTimer(1, LoadLevel);
    }

    private void LoadLevel()
    {
        Timers.Instance.StartTimer(levels[_currentLevel].levelParameters.passLevelTime, GoToNextLevel);
        InsectManager.Instance.StartInsectSpawning(levels[_currentLevel].levelParameters);
    }

    #endregion

    #region Kill and GameOver Handling
    private void ProcessKillings(GameObject insect)
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


    private void GameOver()
    {
        IsTouchable = false;
        
        float score = ResultsController.Instance.Score;
        ScoreRepo.PushScore(score);
        TimeRepo.PushTime(_timer);
        LevelRepo.PushLevel(_currentLevel + 1);

        var loadNextScene = new UnityAction(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        Timers.Instance.StartTimer(1, loadNextScene);
    }
    #endregion


    #region Game Timer Handling

    private void AddToTimer(float seconds)
    {
        _timer += seconds;
        if (gameUIManager != null)

        gameUIManager.UpdateScore(ResultsController.Instance.Score);
    }
    
    private void PauseGame()
    {
        Time.timeScale = 0;
        IsTouchable = false;
        
        pauseButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(true);
    }

    private void PlayGame()
    {
        Time.timeScale = 1;
        IsTouchable = true;
        
        playButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    private void ShowSettingPanel()
    {
        // Pause the game
        PauseGame();
        playButton.onClick.RemoveListener(PlayGame);
        
        // Show the setting panel
        settingPanel.SetActive(true);
        
        // Change the function of setting button
        ChangeButtonFunc(settingButton, ShowSettingPanel, HideSettingPanel);
        
        // Remove powerUp button listener
        ChangeButtonFunc(powerUpsButton, ShowPowerUpsPanel, null);
    }

    private void HideSettingPanel()
    {
        // Play the game again
        playButton.onClick.AddListener(PlayGame);
        PlayGame();
        
        // Hide the setting panel
        settingPanel.SetActive(false);
        
        // Change the function of setting button
        ChangeButtonFunc(settingButton, HideSettingPanel, ShowSettingPanel);
        
        // Add powerUp button listener
        ChangeButtonFunc(powerUpsButton, null, ShowPowerUpsPanel);
    }

    private void ShowPowerUpsPanel()
    {
        // Pause the game
        PauseGame();
        playButton.onClick.RemoveListener(PlayGame);
        
        // Show powerUps panel
        powerUpsPanel.SetActive(true);
        
        // Change the function of powerUps button
        ChangeButtonFunc(powerUpsButton, ShowPowerUpsPanel, HidePowerUpsPanel);
        
        // Remove setting button listener
        ChangeButtonFunc(settingButton, ShowSettingPanel, null);
    }

    private void HidePowerUpsPanel()
    {
        // Play the game
        playButton.onClick.AddListener(PlayGame);
        PlayGame();
        
        // Hide powerUps panel
        powerUpsPanel.SetActive(false);
        
        // Change the function of powerUps button
        ChangeButtonFunc(powerUpsButton, HidePowerUpsPanel, ShowPowerUpsPanel);
        
        // Add setting button listener
        ChangeButtonFunc(settingButton, null, ShowSettingPanel);
        
    }

    private void ChangeButtonFunc(Button btn, UnityAction lastListener, UnityAction newListener)
    {
        if(lastListener != null)
            btn.onClick.RemoveListener(lastListener);
        if(newListener != null)
            btn.onClick.AddListener(newListener);
    }

    #endregion
}
