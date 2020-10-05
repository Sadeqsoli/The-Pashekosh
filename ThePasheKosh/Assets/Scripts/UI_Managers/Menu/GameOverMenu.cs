using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using RTLTMPro;

public class GameOverMenu : MonoBehaviour
{
    [Space]
    public RTLTextMeshPro scoreText;
    [Space]
    public RTLTextMeshPro highScoreText;
    [Space]
    public RTLTextMeshPro levelText;
    [Space]
    public RTLTextMeshPro timeText;

    void Delete()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("Deleted");
    }

    public void GoToRunningState()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
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
        highScoreText.text = "Best Score: " + highScore.ToString();
        timeText.text = "Best Time " + time.ToString();
        levelText.text = "Level " + level.ToString();
    }
}

