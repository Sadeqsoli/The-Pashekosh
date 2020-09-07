using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;

public class UIManager : MonoBehaviour
{
    public RTLTextMeshPro timerText;
    [Space]
    public RTLTextMeshPro scoreText;
    [Space]
    public RTLTextMeshPro killNumberText;
    [Space]
    public RTLTextMeshPro levelText;
    [Space]
    public RTLTextMeshPro healthText;

    public void UpdateTimer(float time)
    {
        timerText.text = time.ToString("F0");
    }

    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString("F0");
    }

    public void UpdateLevel(int levelNum)
    {
        levelText.text = levelNum.ToString();
    }

    public void UpdateHealth(float health)
    {
        healthText.text = health.ToString("F1");
    }

    public void UpdateKillNumber(int killNum)
    {
        killNumberText.text = killNum.ToString();
    }

    public void Initialize(float time = 0,
        float score = 0, float health = 0, int killNumber = 0, int level = 0)
    {
        

        timerText.text = time.ToString("F0");
        scoreText.text = score.ToString("F0");
        healthText.text = health.ToString("F1");
        killNumberText.text = killNumber.ToString();
        levelText.text = level.ToString();
    }
}
