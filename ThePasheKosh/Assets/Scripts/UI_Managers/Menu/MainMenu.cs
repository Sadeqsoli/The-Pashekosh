using RTLTMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Static<MainMenu>
{
    [SerializeField] Button SettingButton;
    [SerializeField] Button ShopButton;
    [SerializeField] Button StartButton;


    [SerializeField] RTLTextMeshPro CoinCounterTXT;
    [SerializeField] RTLTextMeshPro levelProgressionTXT;
    [SerializeField] RTLTextMeshPro highScoreTXT;

    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject UsernamePanel;

    Canvas canvas;

    public void DeletingKeys()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SetCoinsText();
    }
    public void AddCoinsDebug(int coins)
    {
        CoinRepo.PushCoins(coins);
        SetCoinsText();
    }


    public void SetCoinsText()
    {
        CTween.ToInt(0, CoinRepo.GetCoins(),1,delegate 
        {
            CoinCounterTXT.text = CoinRepo.GetCoins().ToString();
        },
        delegate 
        {
            CoinCounterTXT.transform.Scaler(TTScale.ShakeIt);
        });

        //SetScoresAndLevelProgressionText();
    }

    void OnEnable()
    {
        ShakeThingsOff();
    }
    void Start()
    {
        SetValues();
        AddButtonListeners();
        SignUpCheck();
        //CheckforScore();
        SetCoinsText();
    }

    void SetValues()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = CamTrack.Instance.GetComponent<Camera>();
        SettingPanel.SetActive(false);
        ShopPanel.SetActive(false);
        UsernamePanel.SetActive(false);
    }


    void AddButtonListeners()
    {
        ShopButton.onClick.AddListener(GoToShop);
        SettingButton.onClick.AddListener(GoToSetting);
        StartButton.onClick.AddListener(GoToGameScene);
    }

    void ShakeThingsOff()
    {
        CoinCounterTXT.transform.Scaler(TTScale.ShakeIt);
        ShopButton.transform.Scaler(TTScale.ShakeIt);
        SettingButton.transform.Scaler(TTScale.ShakeIt);
        StartButton.transform.Scaler(TTScale.ShakeIt);
    }

    void GoToShop()
    {
        ShopPanel.SetActive(true);
    }
    void GoToSetting()
    {
        SettingPanel.SetActive(true);
    }
    void GoToGameScene()
    {
        SceneController.Instance.GoToNextOrPrevScene(true);
    }


    void SignUpCheck()
    {
        if (UserRepo.IsUserSignedIn())
        {
            UsernamePanel.SetActive(false);
        }
        else
        {
            UsernamePanel.transform.Scaler(TTScale.ScaleUp);
        }
    }
    void CheckforScore()
    {
        if (!PlayerPrefs.HasKey(ScoreRepo.AllScoreRepoKey))
        {
            levelProgressionTXT.gameObject.SetActive(false);
            highScoreTXT.gameObject.SetActive(false);
        }
        else
        {
            SetScoresAndLevelProgressionText();
        }
    }
    void SetScoresAndLevelProgressionText()
    {
        levelProgressionTXT.gameObject.SetActive(true);
        levelProgressionTXT.text = LevelRepo.GetLevel().ToString();
        highScoreTXT.gameObject.SetActive(true);
        highScoreTXT.text = ScoreRepo.GetHighScore().ToString();
    }


}//EndClassss
