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

    // Fields --->>>

    FoodType _currentTarget = FoodType.Spagetti;
    GameState _currentState = GameState.MainMenu;

    SpriteRenderer _spriteRenderer;


    // Serilized Field --->>>

    [Space] // Array of design for diffrent targets.
    [SerializeField] GameObject[] TableDesigns;

    [Space] // Sprite of every background.
    List<Sprite> SpriteOfTargets = new List<Sprite>();

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

                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Pizza: //Glass Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Cake: //Brown Wooden Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.IceCream: //Metall Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Burger: //Plastic Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.QormehSabzi:  //Iranian Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.Chicken:  //Glass Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case FoodType.KalehPache:  //Stone Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
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
        int rnd = Random.Range(0, TableDesigns.Length);
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
        DirectoryInfo dir = new DirectoryInfo(DB.LocalBackgroundDIR());
        FileInfo[] fileInfo = dir.GetFiles("*.*");
        foreach (FileInfo file in fileInfo)
        {
            NetCenter.Instance.DownloadImage(DB.LocalMusics(file.Name), AddSprite);
        }
    }


    void AddSprite(Sprite sprite)
    {
        SpriteOfTargets.Add(sprite);
    }
}//EndClassss
