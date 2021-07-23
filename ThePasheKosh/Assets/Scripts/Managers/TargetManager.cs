using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class TargetManager : AbsSingleton<TargetManager>
{
    // Initializers --->>>
    public enum GameState { MainMenu, GamePlay, GameOver }


    // Properties --->>>
    public FoodType CurrentTarget { get { return _currentTarget; } }
    public GameState CurrentGameState { get { return _currentState; } }

    public static bool isSplashed { get; set; } = false;


    // Fields --->>>

    FoodType _currentTarget = FoodType.Spagetti;
    GameState _currentState = GameState.MainMenu;

    SpriteRenderer _spriteRenderer;


    // Serilized Field --->>>

    [Space] // Array of design for diffrent targets.
    [SerializeField] GameObject[] TableDesigns;

    [Space] // Sprite of every background.
    [SerializeField] List<Sprite> SpriteOfTargets = new List<Sprite>();

    public void UpdateBackground(FoodType bgType)
    {
        _currentTarget = bgType;

        //For Changing table design with every Background Update
        SetActiveRandomTableDesigns();
        //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
        //ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
        switch (bgType)
        {
            case FoodType.Spagetti://WhiteWooden Table

                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Pizza: //Glass Table
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Cake: //Brown Wooden Table
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.IceCream: //Metall Table
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Burger: //Plastic Table
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.QormehSabzi:  //Iranian Table
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Chicken:  //Glass Table
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.KalehPache:  //Stone Table
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;
        }
    }


    public void UpdateGameState(GameState gameState)
    {
        _currentState = gameState;
        switch (gameState)
        {
            case GameState.MainMenu:

                break;
            case GameState.GamePlay:

                break;
            case GameState.GameOver:

                break;
        }
    }




    void Start()
    {
        InitializingAllBackground();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CameraScaler.CameraFit(_spriteRenderer);
        UpdateBackground(_currentTarget);
    }//Starttttt



    void ChangeRelatedSprite(Sprite _sprite)
    {
        if (_sprite != null)
            _spriteRenderer.sprite = _sprite;
    }
    void SetActiveRandomTableDesigns()
    {
        int rnd = UnityEngine.Random.Range(0, TableDesigns.Length);
        if (TableDesigns.Length > 0)
            for (int i = 0; i < TableDesigns.Length; i++)
            {
                if (rnd == i)
                {
                    TableDesigns[i].transform.Scaler(TTScale.ScaleUp);
                }
                else
                {
                    TableDesigns[i].SetActive(false);
                }
            }
    }

    public void InitializingAllBackground()
    {
        string[] targetNames = Enum.GetNames(typeof(FoodType));
        int targetLength = targetNames.Length;
        for (int i = 0; i < targetLength; i++)
        {
            string path = DB.LocalBackPath(targetNames[i]);
            Sprite sprite = Resourcer.SpriteLoader(path);
            SpriteOfTargets.Add(sprite);
        }
    }


    void AddSprite(Sprite sprite)
    {
        SpriteOfTargets.Add(sprite);
    }
}//EndClassss
