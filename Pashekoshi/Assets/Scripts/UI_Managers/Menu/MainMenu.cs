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

    [SerializeField] GameObject ShopPanel;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject UsernamePanel;

    Canvas canvas;

    const string firstTime= "FirstTime";


    void DeletingKeys()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        SceneController.Instance.ResetScene();
    }
    public void AddCoinsDebug(int coins)
    {
        CoinRepo.PushCoins(coins);
        SetCoinsText();
    }


    public void SetCoinsText()
    {
        CTween.ToInt(0, CoinRepo.GetCoins(), 1, () =>
          {
              CoinCounterTXT.text = CoinRepo.GetCoins().ToString();
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
        //SignUpCheck();
        //CheckforScore();
        if (!PlayerPrefs2.GetBool(firstTime))
        {
            AddCoinsDebug(2000);
            PlayerPrefs2.SetBool(firstTime, true);
        }
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
        ShopButton.transform.Scaler(TTScale.ScaleUp);
        SettingButton.transform.Scaler(TTScale.ScaleUp);
        StartButton.transform.Scaler(TTScale.ScaleUp);
    }

    void GoToShop()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        ShopPanel.transform.Scaler(TTScale.ScaleUp, () =>
         {
         });

    }
    void GoToSetting()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        SettingPanel.transform.Scaler(TTScale.ScaleUp, () =>
        {
        });
    }
    void GoToGameScene()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        SceneController.Instance.GoToNextOrPrevScene(true, true);
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


}//EndClassss
