using UnityEngine;
using TMPro;


public class GameOverMenu : MonoBehaviour
{
    [Space]
    public TextMeshProUGUI scoreText;
    [Space]
    public TextMeshProUGUI levelText;

    void Delete()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted");
    }

    public void GoToRunningState()
    {
        HelperSceneManager.GoToAnotherScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Delete();
        float score = ScoreRepo.GetLastScore();
        float highScore = ScoreRepo.GetHighScore();
        float time = TimeRepo.GetLastTime();
        int level = LevelRepo.GetLevel();

        scoreText.text = "Score: "  + ((int)score).ToString();
        //highScoreText.text = "Best Score: " + highScore.ToString();
        //timeText.text = "Best Time " + time.ToString();
        levelText.text = "Level " + level.ToString();
    }
}

