using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;

public class UIManager : MonoBehaviour
{
    
    public RTLTextMeshPro scoreText;
    [Space]
    public Image healthFillBar;

    [Space] 
    public Color green;
    public Color yellow;
    public Color red;
    
    private float maxHealth = 100f;

    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString("F0");
    }

    public void UpdateHealth(float health)
    {
        float percent = health / maxHealth;
        
        healthFillBar.fillAmount = health / maxHealth;

        if (percent < 0.33f)
        {
            healthFillBar.color = green;
        }
        else if (percent > 0.33f && percent < 0.66f)
        {
            healthFillBar.color = yellow;
        }
        else
        {
            healthFillBar.color = red;
        }
    }

    public void Initialize(float score = 0, float health = 100)
    {
        scoreText.text = score.ToString("F0");
        maxHealth = health;
    }
}
