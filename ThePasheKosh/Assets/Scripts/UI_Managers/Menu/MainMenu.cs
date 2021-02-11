using RTLTMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
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








    void Start()
    {
        SetValues();
        AddButtonListeners();
        SignUpCheck();
        CheckforScore();
        SetCoinsText();
    }

    void SetValues()
    {
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    void SignUpCheck()
    {
        if (!PlayerPrefs.HasKey(UserRepo.RepoUser))
        {
            UsernamePanel.SetActive(true);
        }
        else if (PlayerPrefs.HasKey(UserRepo.RepoUser))
        {
            UsernamePanel.SetActive(false);
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
    void SetCoinsText()
    {
        CoinCounterTXT.text = CoinRepo.GetCoins().ToString();
    }

}//EndClassss
