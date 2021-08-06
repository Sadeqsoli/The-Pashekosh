using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

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
    public Toggle PlayPauseToggle;

    // Setting panel/button that is added through inspector
    [Space]
    public Toggle settingButton;
    public GameObject settingPanel;

    // Power Ups panel/button that is added through inspector
    [Space]
    public Toggle powerUpsButton;
    public GameObject powerUpsPanel;

    public Sprite openPanelSprite, closePanelSprite;
    public Sprite playSprite, pauseSprite;

    #endregion

    #region Private Variables

    private int foodIndex = 0;
    private int currentLevel;

    private float timer;

    #endregion

    #region Properties

    // Make it false, whenever we don't want the player touches have impact on the game
    public static bool IsNormalWeaponActive { private set; get; }
    public static bool IsElectricalPkActive { private set; get; }
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
        settingPanel.SetActive(false);
        powerUpsPanel.SetActive(false);

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

        // Show the food in the game
        FoodManager.Instance.MakeFoodReady(foods[foodIndex]);

        // Make sure that the game is touchable
        IsNormalWeaponActive = true;
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
            EventManager.AddEventWithNoParamter(Events.ZeroHealth);
            // Whenever an insect is killed, this event will be invoked with the insect game object as a parameter
            EventManager.AddGameObjectEvent(Events.InsectKilled);

            // Whenever a piece of food is completely destroyed, this event will be invoked
            EventManager.AddEventWithNoParamter(Events.FoodDestruction);

            // Whenever we want to mute or unmute the insects and background sounds
            EventManager.AddBoolEvent(Events.BackgroundSound);
            EventManager.AddBoolEvent(Events.InsectsSound);

            // Events that are realted to Power Ups buttons
            EventManager.AddEventWithNoParamter(Events.ElectricalPasheKosh);
            EventManager.AddEventWithNoParamter(Events.Fan);
            EventManager.AddEventWithNoParamter(Events.Pill);
            EventManager.AddEventWithNoParamter(Events.Spray);

            // Events that are related to Power Ups actions
            EventManager.AddEventWithNoParamter(Events.ElectricalPasheKoshTriggered);
            EventManager.AddEventWithNoParamter(Events.FanTriggered);
            EventManager.AddEventWithNoParamter(Events.PillTriggered);
            EventManager.AddEventWithNoParamter(Events.SprayTriggered);
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

        // Add toggles listeners
        PlayPauseToggle.onValueChanged.AddListener(PlayPauseGame);

        settingButton.onValueChanged.AddListener(ShowHideSettingPanel);
        powerUpsButton.onValueChanged.AddListener(ShowHidePowerUpsPanel);
    }

    #endregion

    #region Level Handling

    private void GoToNextLevel()
    {
        InsectManager.Instance.StopAllSpawn(false);

        if (currentLevel < levels.Length - 1)
            currentLevel++;

        Timers.Instance.StartTimer(1, LoadLevel);
    }

    private void LoadLevel()
    {
        Timers.Instance.StartTimer(levels[currentLevel].levelParameters.passLevelTime, GoToNextLevel);
        InsectManager.Instance.StartInsectSpawning(levels[currentLevel].levelParameters);
        LevelRepo.PushLevel(currentLevel);
        Debug.Log("currentLevel: " + currentLevel);
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
        IsNormalWeaponActive = false;

        float score = ResultsController.Instance.Score;
        ScoreRepo.PushScore(score);
        TimeRepo.PushTime(timer);
        LevelRepo.PushLevel(currentLevel + 1);

        var loadNextScene = new UnityAction(() => SceneController.Instance.GoToNextOrPrevScene(true));
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


    private void PlayPauseGame(bool isGamePaused)
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;

            IsNormalWeaponActive = false;
            IsElectricalPkActive = false;

            PlayPauseToggle.image.sprite = playSprite;
        }
        else
        {
            Time.timeScale = 1;
            Timers.Instance.StartTimer(0.1f, PlayGameWithDelay);
        }
    }

    private void PlayGameWithDelay()
    {
        if (gameState == GameStates.Normal)
            IsNormalWeaponActive = true;
        else if (gameState == GameStates.ElectricalPasheKosh)
            IsElectricalPkActive = true;


        PlayPauseToggle.image.sprite = pauseSprite;
    }

    private void ShowHideSettingPanel(bool isPanelOn)
    {
        powerUpsPanel.SetActive(false);
        if (isPanelOn)
        {
            // Show the setting panel
            settingPanel.transform.Scaler(TTScale.ScaleUp, () =>
            {
                // Pause the game
                PlayPauseGame(true);
            });

        }
        else
        {
            // Play the game again
            PlayPauseGame(false);


            // Hide the setting panel
            settingPanel.transform.Scaler(TTScale.ScaleDown);

        }


    }

    private void ShowHidePowerUpsPanel(bool isPanelOn)
    {
        settingPanel.SetActive(false);
        if (isPanelOn)
        {
            // Show the powerUps panel
            powerUpsPanel.transform.Scaler(TTScale.XScaleUp, () =>
             {
                 powerUpsButton.image.sprite = closePanelSprite;
                 // Pause the game
                 PlayPauseGame(true);
             });
        }
        else
        {
            // Play the game again
            PlayPauseGame(false);

            // Hide the powerUps panel
            powerUpsPanel.transform.Scaler(TTScale.XScaleDown);
            powerUpsButton.image.sprite = openPanelSprite;
        }
    }


    #endregion

    #region PowerUps Handling

    private void UseElectricalPK()
    {
        UsePowerUps(GameStates.ElectricalPasheKosh);
        Timers.Instance.StartTimer(10f, FinishPowerUp);
        IsElectricalPkActive = true;
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
        ShowHidePowerUpsPanel(false);
        gameState = currentState;
        IsNormalWeaponActive = false;
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
        isPowerUpActive = false;
        IsElectricalPkActive = false;

        gameState = GameStates.Normal;
        IsNormalWeaponActive = true;
    }


    #endregion
}
