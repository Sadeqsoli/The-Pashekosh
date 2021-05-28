using UnityEngine;
using RTLTMPro;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [Space]
    [SerializeField] RTLTextMeshPro HighestLevelProgressionTXT;
    [Space]
    [SerializeField] RTLTextMeshPro LastScoreTXT;
    [Space]
    [SerializeField] Button GoToMainButton;


    void Start()
    {
        //Delete();

        DisplayLatestScores(ScoreRepo.GetLastScore());
        DisplayBestOpenedLevel(LevelRepo.GetLevel());

        GoToMainButton.onClick.AddListener(()=> SceneController.Instance.GoToSpecificScene(0));
    }



    void DisplayLatestScores(float lastScore)
    {
        if(lastScore == 0f)
        {
            LastScoreTXT.text = lastScore.ToString() /*+ "بهترین امتیاز "*/;
        }
        else
        {
            LastScoreTXT.text = lastScore.ToString("##.#") /*+ "بهترین امتیاز "*/;
        }
    }
    void DisplayBestOpenedLevel(int bestLevel)
    {
        HighestLevelProgressionTXT.text = bestLevel.ToString() /*+ "بهترین مرحله "*/;
    }






    void Delete()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted");
    }

}//EndClassss

