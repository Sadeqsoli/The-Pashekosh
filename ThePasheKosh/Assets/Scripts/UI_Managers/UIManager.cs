using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;

public class UIManager : MonoBehaviour
{
    
    public RTLTextMeshPro scoreText;
    [Space]
    public Image healthFillBar;

    
    private float maxHealth = 100f;

    public void UpdateScore(float score)
    {
        scoreText.text = score.ToString("F0");
    }

    public void UpdateHealth(float health)
    {
        healthFillBar.fillAmount = health / maxHealth;
    }

    public void Initialize(float score = 0, float health = 100)
    {
        scoreText.text = score.ToString("F0");
        maxHealth = health;
    }
}
