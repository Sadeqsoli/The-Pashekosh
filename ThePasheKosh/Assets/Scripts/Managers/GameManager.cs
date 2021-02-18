using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public enum GameStates
{
    Normal,
    ElectricalPasheKosh,
    Fan,
    Spray,
    Pill
}

public class GameManager : Singleton<GameManager>
{
    #region Public Variables

    // The state of the game (in terms of using power ups)
    public static GameStates gameState = GameStates.Normal;
    public static bool isPowerUpActive = false;
    
    // Levels information that is added through inspector
    public LevelParameters[] levels;

    // Foods information that is added through inspector
    [FormerlySerializedAs("cakes")]
    [Space]
    [Space]
    public List<FoodInfo> foods;

    // Game UI Manager that is added through inspector
    [Space]
    [Space]
    public UIManager gameUIManager;

    // Play/Pause buttons that is added through inspector
    [Space] 
    public Button playButton;
    public Button pauseButton;

    // Setting panel/button that is added through inspector
    [Space] 
    public Button settingButton;
    public GameObject settingPanel;
    
    // Power Ups panel/button that is added through inspector
    [Space] 
    public Button powerUpsButton;
    public GameObject powerUpsPanel;
    

    #endregion

    #region Private Variables
    
    private int foodIndex = 0;
    private int currentLevel;

    private float timer;

    #endregion
    
    #region Properties
    
    // Make it false, whenever we don't want the player touches have impact on the game
    public bool IsTouchable { private set; get; }
    #endregion
    
    #region Unity Methods
    private void Start()
    {
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
        timer = 0;
        Timers.Instance.StartRepeatedAction(1f, AddToTimer);

        // Initializing GameUIManager
        gameUIManager.Initialize(0, 100);
        
        // Initializing PowerUps
        var powerUpNumbers = GetPowerUpsNum();
        PowerUpsManager.Initialize(powerUpNumbers);
        
        // Show the food in the game
        FoodManager.Instance.MakeTheFoodReady(foods[foodIndex]);
        
        // Make sure that the game is touchable
        IsTouchable = true;
    }
    
    #endregion 
    
    #region Updating Health
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
            
            // Events that are realted to Power Ups
            EventManager.AddEventWithNoParamter(Events.ElectricalPasheKosh);
            EventManager.AddEventWithNoParamter(Events.Fan);
            EventManager.AddEventWithNoParamter(Events.Pill);
            EventManager.AddEventWithNoParamter(Events.Spray);
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
        
        EventManager.StartListening(Events.ElectricalPasheKosh, UseElectricalPK);
        EventManager.StartListening(Events.Fan, UseFan);
        EventManager.StartListening(Events.Pill, UsePill);
        EventManager.StartListening(Events.Spray, UseSpray);

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

        if(currentLevel < levels.Length - 1)
            currentLevel++;

        Timers.Instance.StartTimer(1, LoadLevel);
    }

    private void LoadLevel()
    {
        Timers.Instance.StartTimer(levels[currentLevel].levelParameters.passLevelTime, GoToNextLevel);
        InsectManager.Instance.StartInsectSpawning(levels[currentLevel].levelParameters);
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
        TimeRepo.PushTime(timer);
        LevelRepo.PushLevel(currentLevel + 1);

        var loadNextScene = new UnityAction(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        Timers.Instance.StartTimer(1, loadNextScene);
    }
    #endregion

    #region Game Timer Handling

    private void AddToTimer(float seconds)
    {
        timer += seconds;
        if (gameUIManager != null)
            gameUIManager.UpdateScore(ResultsController.Instance.Score);
    }
    #endregion
    
    #region Game Buttons Hanlding
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
    
    #region PowerUps Handling

    private void UseElectricalPK()
    {
        UsePowerUps(GameStates.ElectricalPasheKosh);
    }

    private void UseFan()
    {
        UsePowerUps(GameStates.Fan);
    }

    private void UsePill()
    {
        UsePowerUps(GameStates.Pill);
    }

    private void UseSpray()
    {
        UsePowerUps(GameStates.Spray);
    }

    private void UsePowerUps(GameStates currentState)
    {
        HidePowerUpsPanel();
        gameState = currentState;
        IsTouchable = false;
        isPowerUpActive = true;
        StartCoroutine(UsePowerUpsCo());
    }

    private IEnumerator UsePowerUpsCo()
    {
        yield return new WaitUntil(() => !isPowerUpActive);
        FinishPowerUp();
    }

    private void FinishPowerUp()
    {
        gameState = GameStates.Normal;
        IsTouchable = true;
    }

    private PowerUpNumbers GetPowerUpsNum()
    {
        PowerUpNumbers powerUpNumbers = new PowerUpNumbers();
        if (PlayerPrefs.HasKey(PowerUps.ElectricalPasheKosh))
        {
            powerUpNumbers.electricalPasheKoshNum = PlayerPrefs.GetInt(PowerUps.ElectricalPasheKosh);
            powerUpNumbers.fanNum = PlayerPrefs.GetInt(PowerUps.Fan);
            powerUpNumbers.pillNum = PlayerPrefs.GetInt(PowerUps.Pill);
            powerUpNumbers.sprayNum = PlayerPrefs.GetInt(PowerUps.Spray);
        }
        else
        {
            Debug.Log("Number Of PowerUps haven't saved from Main Menu Scene.");
            powerUpNumbers.electricalPasheKoshNum = 0;
            powerUpNumbers.fanNum = 0;
            powerUpNumbers.pillNum = 0;
            powerUpNumbers.sprayNum = 0;
        }

        return powerUpNumbers;
    }
    #endregion
}
