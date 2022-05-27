using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthFill : MonoBehaviour
{
    static Image fillImage;

    static float health = 1;
    private void Start()
    {
        fillImage = GetComponent<Image>();
        SetColor();
    }
    public static void ShowHealth(float value, float maxHealth)
    {
        ShowHealth(value / maxHealth);
    }

    public static void ShowHealth(float healthPercentage)
    {
        health = healthPercentage;
        fillImage.fillAmount = healthPercentage;
        SetColor();
    }

    static void SetColor()
    {
        if(health > 0.70)
        {
            fillImage.color = Color.green;
        }
        else if(health < 0.7 && health > 0.3)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.red;
        }
    }
}
