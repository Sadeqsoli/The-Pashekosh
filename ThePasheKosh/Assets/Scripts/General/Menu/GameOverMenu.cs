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



    public void GoToRunningState()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        float score = PlayerPrefs.GetFloat("Score");
        float highScore = PlayerPrefs.GetFloat("HighScore");
        float time = PlayerPrefs.GetFloat("Time");
        int level = PlayerPrefs.GetInt("Level");

        scoreText.text = score.ToString();
        highScoreText.text = highScore.ToString();
        timeText.text = time.ToString();
        levelText.text = level.ToString();
    }
}

