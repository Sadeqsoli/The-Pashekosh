using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    public int multiplier = 5;
    [SerializeField] GameObject DirectReplayOBJ;
    [Space]
    [SerializeField] RTLTextMeshPro HighestLevelProgressionTXT;
    [Space]
    [SerializeField] RTLTextMeshPro HighestLevelProgressionDesTXT;
    [Space]
    [SerializeField] RTLTextMeshPro LastScoreTXT;
    [Space]
    [SerializeField] RTLTextMeshPro LastScoreDesTXT;
    [Space]
    [SerializeField] Button RaplayButton;
    [Space]
    [SerializeField] Button ShopButton;
    [Space]
    [SerializeField] Button GoToMainButton;
    [Space]
    [SerializeField] GO_Shop GO_ShopPanel;

    Canvas canvas;

    void Awake()
    {
        if (UserRepo.GetPushUserCycleNumber() % multiplier == 0)
        {
            DirectReplayOBJ.SetActive(false);
            GO_ShopPanel.transform.Scaler(TTScale.ScaleUp);
        }
        else
        {
            GO_ShopPanel.gameObject.SetActive(false);
            DirectReplayOBJ.transform.Scaler(TTScale.ScaleUp);
        }
    }


    void Start()
    {
        //Delete();
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = CamTrack.Instance.GetComponent<Camera>();

        DisplayLatestScores(ScoreRepo.GetLastScore());
        DisplayBestOpenedLevel(LevelRepo.GetLevel());
        ShopButton.ChangeListener(GoToShop);
        RaplayButton.onClick.AddListener(GetBackToGamePlay);
        GoToMainButton.onClick.AddListener(() => SceneController.Instance.GoToSpecificScene(0));

    }
    void GetBackToGamePlay()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        SceneController.Instance.GoToNextOrPrevScene(false, true);
    }
    void GoToShop()
    {
        SFXPlayer.Instance.PlaySFX(UIFeedback.ButtonClick);
        DirectReplayOBJ.SetActive(false);
        GO_ShopPanel.transform.Scaler(TTScale.ScaleUp);

    }

    void DisplayLatestScores(float lastScore)
    {
        if (ScoreRepo.PushHighScore(lastScore))
        {
            LastScoreDesTXT.text = "بهترین امتیاز ";
            if (lastScore <= 0f)
            {
                LastScoreTXT.text = ScoreRepo.GetHighScore().ToString();
            }
            else
            {
                LastScoreTXT.text = ScoreRepo.GetHighScore().ToString();
            }
            Debug.Log("High: " + ScoreRepo.GetHighScore());
            Debug.Log("Last: " + ScoreRepo.GetLastScore());
            Debug.Log("Last: " + lastScore);
        }
        else
        {
            LastScoreDesTXT.text = "آخرین امتیاز";
            if (lastScore <= 0f)
            {
                LastScoreTXT.text = 0.ToString();
            }
            else
            {
                LastScoreTXT.text = lastScore.ToString();
            }
            Debug.Log("High: " + ScoreRepo.GetHighScore());
            Debug.Log("Last: " + ScoreRepo.GetLastScore());
            Debug.Log("Last: " + lastScore);
        }

    }
    void DisplayBestOpenedLevel(int bestLevel)
    {
        HighestLevelProgressionDesTXT.text = "بهترین مرحله";
        HighestLevelProgressionTXT.text = bestLevel.ToString();
    }






    void Delete()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted");
    }

}//EndClassss

