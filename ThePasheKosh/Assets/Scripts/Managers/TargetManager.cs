using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(SpriteRenderer))]
public class TargetManager : AbsSingleton<TargetManager>
{
    // Initializers --->>>
    public enum TargetType { Spagetti, Pitzza, Cake, IceCream, Hamberger, GhormehSabzi, Chicken, KalehPacheh }
    public enum GameState { MainMenu, GamePlay, GameOver }


    // Properties --->>>
    public TargetType CurrentTarget { get { return _currentTarget; } }
    public GameState CurrentGameState { get { return _currentState; } }

    // Fields --->>>

    TargetType _currentTarget = TargetType.Spagetti;
    GameState _currentState = GameState.MainMenu;

    AudioSource _audioSource;
    SpriteRenderer _spriteRenderer;


    // Serilized Field --->>>

    [Space] // Array of design for diffrent targets.
    [SerializeField] GameObject[] TableDesigns;

    [Space] // Sounds for background Selection feedback
    [SerializeField] AudioClip[] SoundAfterSelection;

    [Space] // Sprite of every background.
    [SerializeField] Sprite[] SpriteOfTargets;

    public void UpdateBackground(TargetType bgType)
    {
        _currentTarget = bgType;

        //For Changing table design with every Background Update
        SetActiveRandomTableDesigns();
        //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
        //ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
        switch (bgType)
        {
            case TargetType.Spagetti://WhiteWooden Table

                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case TargetType.Pitzza: //Glass Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case TargetType.Cake: //Brown Wooden Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case TargetType.IceCream: //Metall Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case TargetType.Hamberger: //Plastic Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case TargetType.GhormehSabzi:  //Iranian Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case TargetType.Chicken:  //Glass Table
                //PlaybackRelatedAudio(SoundAfterSelection[(int)bgType]);
                ChangeRelatedSprite(SpriteOfTargets[(int)bgType]);
                break;


            case TargetType.KalehPacheh:  //Stone Table
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
        _audioSource = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CameraScaler.CameraFit(_spriteRenderer);
        UpdateBackground(_currentTarget);
    }//Starttttt

    void PlaybackRelatedAudio(AudioClip _clip)
    {
        if (_clip != null)
            _audioSource.PlayOneShot(_clip);
    }
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
                if(rnd == i)
                {
                    TableDesigns[i].SetActive(true);
                }
                else
                {
                    TableDesigns[i].SetActive(false);
                }
            }
    }


}//EndClassss
