using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [Space]
    [SerializeField] RTLTextMeshPro HighestLevelProgressionTXT;
    [Space]
    [SerializeField] RTLTextMeshPro HighestLevelProgressionDesTXT;
    [Space]
    [SerializeField] RTLTextMeshPro LastScoreTXT;
    [Space]
    [SerializeField] RTLTextMeshPro LastScoreDesTXT;
    [Space]
    [SerializeField] Button GoToMainButton;

    Canvas canvas;

    void Start()
    {
        //Delete();
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = CamTrack.Instance.GetComponent<Camera>();

        DisplayLatestScores(ScoreRepo.GetLastScore());
        DisplayBestOpenedLevel(LevelRepo.GetLevel());

        GoToMainButton.onClick.AddListener(() => SceneController.Instance.GoToSpecificScene(0));
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

